using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	class ProjectDependencyValidation : IProjectValidator
	{
		public IEnumerable<IValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			foreach (IDependency dependency in project.Operations().AllDependencies)
			{
				if (dependency.ReferenceOperations().IsSnapshot && !project.ReferenceOperations().IsSnapshot)
				{
					yield return new ValidationProblem
					{
						Severity = ProblemSeverity.ProjectWarning,
						Description = string.Format("released project {0} depends on SNAPSHOT {1}", project, dependency)
					};
				}

				var result = ValidateDependency(context, project, dependency);
				if (result != null)
				{
					yield return result;
				}

				//	if (potencial.Length > 1)
				//	{
				//		error.Details = string.Format("Project {0} dependency {1} not resolved. Multiple corresponding projects found.", projectNode.Project, dependencyReference);
				//		foreach (var candicate in potencial)
				//		{
				//			error.AddFix(new ApplyVersionFix(projectNode.Project, dependencyReference, candicate.Version));
				//		}
				//		AddError(error);
				//		continue;
				//	}

				//	var dependencyProject = potencial.Single();
				//	string realDependencyVersion = dependencyProject.Version;


				//	if (!string.IsNullOrEmpty(realDependencyVersion) && realDependencyVersion != dependencyReference.Version)
				//	{
				//		error.Details = string.Format("Project {0} depends on {1} but tree contains {2}.", 
				//			projectNode.Project, dependencyReference, dependencyProject);

				//		error.AddFix(new ApplyVersionFix(projectNode.Project, dependencyReference, realDependencyVersion));
				//		ValidationErrors.Add(error);
				//	}
			}
		}

		private IValidationProblem ValidateDependency(IExecutionContext context, IProject project, IDependency dependency)
		{
			var operation = dependency.ReferenceOperations();

			if (operation.HasSpecificVersion) // REVIEW: inhereited too
			{
				var potencial = context.AllExtractedProjects.
					Where(p => operation.ReferenceEqualTo(p, false)).ToArray();

				if (potencial.Length == 0)
				{
					// TODO: should we ignore specific version???
					return new ValidationProblem // TODO: fixable
					{
						Severity = ProblemSeverity.ProjectWarning,
						Description = string.Format("Project {0} uses unknown dependency {1}", project, dependency)
					};
					//		error.AddFix(new AddExternalModuleFix(_externalModules, dependency));
				}
				var exact = potencial.SingleOrDefault(p => operation.VersionEqualTo(p.Version));
				if (exact != null)
				{
					return null;
				}

				if (potencial.Length == 1)
				{
					return new ValidationProblem // TODO: fixable
					{
						Severity = ProblemSeverity.ProjectWarning,
						Description = string.Format("Project {0} uses different dependency version {1}", project, dependency)
					};
					//		error.AddFix(new ApplyVersionFix(_projectNode.Project, dependency, potencial.Single().Version));
				}
				return new ValidationProblem // TODO: fixable
				{
					Severity = ProblemSeverity.ProjectWarning,
					Description = string.Format("Project {0} dependency version {1} is wrong. Found multiple potencial candidates", project, dependency)
				};
				//		foreach (var candicate in potencial)
				//		{
				//			error.AddFix(new ApplyVersionFix(_projectNode.Project, dependency, candicate.Version));
				//		}
			}
			else
			{
				// REVIEW: apply inheritance and dependencyManagement 
				//		error.Level = ErrorLevel.Warning;
				//		error.Details =  string.Format("Project {0} depends on {1}:{2} has no version specified.", 
				//			projectNode.Project, dependencyReference.GroupId, dependencyReference.ArtifactId);
				//		error.AddFix(new ApplyVersionFix(projectNode.Project, dependencyReference, realDependencyVersion));
				//		AddError(error);
				//		continue;

				return null;
			}
		}
	}
}