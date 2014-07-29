using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pustota.Maven.Editor.Externals;
using Pustota.Maven.Editor.Models;
using Pustota.Maven.Editor.Resources;
using Pustota.Maven.Editor.Validations.Fixes;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Editor.Validations
{
	class ProjectsValidations
	{
		private readonly IProjectsRepository _repository;
		private readonly ExternalModulesRepository _externalModules;

		internal ProjectsValidations(IProjectsRepository repository, ExternalModulesRepository externalModules)
		{
			_repository = repository;
			_externalModules = externalModules;
			ValidationErrors = new List<ValidationError>();
		}

		public List<ValidationError> ValidationErrors { get; private set; }

		public void Validate()
		{
			ValidationErrors.Clear();

			try
			{
				if (ValidationLoop())
				{
					AddGlobal("Fatal validation error", "project structure problem");
					return;
				}

				ValidateProjects();
				ValidateDependencies();
				ValidateModules();
				//ValidateParents();
				ValidateExternalModules();
			}
			catch (FatalValidationException)
			{
				AddGlobal("Fatal validation error", "");
			}
			catch (Exception ex)
			{
				AddGlobal(ex.Message, ex.StackTrace);
			}
		}

		private bool ValidationLoop()
		{
			bool fail = false; // REVIEW: do something more readable
			foreach (ProjectNode node in _repository.AllProjectNodes)
			{
				foreach (var validation in BuildValidationSequence(node))
				{
					var validationResult = validation.Validate();
					if (validationResult == ValidationResult.ProjectFatal)
					{
						fail = true;
						break;
					}
				}
			}
			return fail;
		}

		private IEnumerable<IValidation> BuildValidationSequence(ProjectNode node)
		{
			yield return new ParentSpecificVersion(this, node);
			yield return new ProjectSpecificVersion(this, node);
			yield return new ParentReferenceExist(this, node, _repository, _externalModules);
			yield return new ProjectPluginVersions(this, node, _repository, _externalModules);
		}

		private void ValidateProjects()
		{
			foreach (var projectNode in _repository.AllProjectNodes)
			{
				Project project = projectNode.Project;


				if (_repository.AllProjectNodes
					.Any(p => p.ShareGroupAndArtifactWith(project) && p.FullPath != project.FullPath))
				{
					string details = string.Format("There should not exist two or more different project files with the same maven coordinates (group id={0} and artifact id={1})", project.GroupId, project.ArtifactId);
					
					var error = new ValidationError(
						project,
						ErrorsResources.ProjectWithThisGroupAndArtifactIDAlreadyExistsInTree,
						details,
						ErrorLevel.Error);

					ValidationErrors.Add(error);
				}
			}
		}

		private void ValidateDependencies()
		{
			foreach (ProjectNode projectNode in _repository.AllProjectNodes)
			{
				Project project = projectNode.Project; 

				foreach (IDependency dependencyReference in project.AllDependencies)
				{
					var error = new ValidationError(projectNode.Project, "Project dependency error", ErrorLevel.Error);
					if (dependencyReference.HasSpecificVersion && _repository.ContainsProject(dependencyReference, true)) // REVIEW: inhereited too
					{
						if (!projectNode.IsSnapshot && dependencyReference.IsSnapshot())
						{
							error.Details = string.Format("Release project {0} depends on SNAPSHOT project {1}.", project, dependencyReference);
							error.AddFix(new SwitchToSnapshotFix(_repository, projectNode));
							AddError(error);
						}
						continue; // found, nothing to validate
					}
					var potencial = _repository.SelectProjectNodes(dependencyReference, false).ToArray();
					if (potencial.Length == 0)
					{
						if (!IsDependencyIgnored(dependencyReference)) // TODO: should we ignore specific version???
						{
							error.Details = string.Format("Project {0} dependency {1} not resolved.", projectNode.Project, dependencyReference);
							error.AddFix(new AddToExternalFix(_externalModules, dependencyReference));
							ValidationErrors.Add(error);
						}
						continue;
					}
					if (potencial.Length > 1)
					{
						error.Details = string.Format("Project {0} dependency {1} not resolved. Multiple corresponding projects found.", projectNode.Project, dependencyReference);
						foreach (var candicate in potencial)
						{
							error.AddFix(new VersionFix(projectNode.Project, dependencyReference, candicate.Version));
						}
						AddError(error);
						continue;
					}

					var dependencyProject = potencial.Single();
					string realDependencyVersion = dependencyProject.Version;

					if (!dependencyReference.HasSpecificVersion)
					{
						error.Level = ErrorLevel.Warning;
						error.Details =  string.Format("Project {0} depends on {1}:{2} has no version specified.", 
							projectNode.Project, dependencyReference.GroupId, dependencyReference.ArtifactId);
						error.AddFix(new VersionFix(projectNode.Project, dependencyReference, realDependencyVersion));
						AddError(error);
						continue;
					}

					if (!string.IsNullOrEmpty(realDependencyVersion) && realDependencyVersion != dependencyReference.Version)
					{
						error.Details = string.Format("Project {0} depends on {1} but tree contains {2}.", 
							projectNode.Project, dependencyReference, dependencyProject);

						error.AddFix(new VersionFix(projectNode.Project, dependencyReference, realDependencyVersion));
						ValidationErrors.Add(error);
					}
				}
			}
		}

		private void ValidateExternalModules()
		{
			foreach (ExternalModule externalModule in _externalModules.Items)
			{
				if (!_repository.IsItUsed(externalModule))
				{
					ValidationError error = new ValidationError(
						externalModule,
						"The external module is not used",
						externalModule.ToString(), ErrorLevel.Info);

					ExternalModule module = externalModule;
					DelegatedFix fix = new DelegatedFix
					{
						ShouldBeConfirmed = true,
						Title = "Delete external module",
						DelegatedAction = () =>
						{
							_externalModules.Remove(module);
							_externalModules.AllModules.Save();
						}
					};
					error.AddFix(fix);
					ValidationErrors.Add(error);
				}
			}
		}

		bool IsDependencyIgnored(IProjectReference dependencyReference)
		{
			return _externalModules.Contains(dependencyReference, false);
		}

		private void ValidateModules()
		{
			foreach (Project project in _repository.AllProjects)
			{
				string baseDir = Path.GetDirectoryName(project.FullPath);
				if (baseDir == null) continue;
				foreach (var module in project.AllModules)
				{
					string moduleFolderPath = Path.Combine(baseDir, module.Path);
					if (!Directory.Exists(moduleFolderPath))
					{
						string details = string.Format("Project contains a module '{0}' but corresponding folder doesn't exist.", module.Path);
						ValidationErrors.Add(new ValidationError(project, "Module folder doesn't exists", details, ErrorLevel.Error));
						continue;
					}

					string moduleProjectPath = Path.GetFullPath(Path.Combine(moduleFolderPath, ProjectsRepository.ProjectFilePattern));
					if (!File.Exists(moduleProjectPath))
					{
						string details = string.Format("Project contains a module '{0}' but the folder doesn't contain a pom.xml.", module.Path);
						ValidationErrors.Add(new ValidationError(project, "Module project doesn't exists", details, ErrorLevel.Error));
						continue;
					}

					if (_repository.AllProjects.FirstOrDefault(p => PathOperations.ArePathesEqual(moduleProjectPath, p.FullPath)) == null)
					{
						string details = string.Format("Project contains a module '{0}', but corresponding project hasn't been loaded", module.Path);
						var fix = new DelegatedFix
						{
							Title = "Try to load the module",
							DelegatedAction = () => _repository.LoadOneProject(moduleProjectPath)
						};
						var error = new ValidationError(project, "Module hasn't been loaded", details, ErrorLevel.Error);
						error.AddFix(fix);
						ValidationErrors.Add(error);
						continue;
					}
				}
			}
		}
	}
}