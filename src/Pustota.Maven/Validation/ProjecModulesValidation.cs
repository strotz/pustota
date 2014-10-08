using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	class ProjecModulesValidation : IProjectValidator
	{
		public IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			foreach (var module in project.Operations().AllModules)
			{
				var extractor = new ProjectDataExtractor();

				IProject moduleProject;
				if (context.TryGetModule(project, module.Path, out moduleProject))
				{
					if (extractor.Extract(project).Version.IsSnapshot && !extractor.Extract(moduleProject).Version.IsSnapshot)
					{
						yield return new ValidationProblem("modulereleasesnapshot")
						{
							ProjectReference = project,
							Severity = ProblemSeverity.ProjectWarning,
							Description = string.Format("release has SNAPSHOT module {0}", module.Path)
						};
					}
				}
				else
				{
					yield return new ValidationProblem("modulemissing")
					{
						ProjectReference = project,
						Severity = ProblemSeverity.ProjectWarning,
						Description = string.Format("module {0} not found", module.Path)
					};
				}

				// REVIEW: move to tree integrity

				//	if (_repository.AllProjects.FirstOrDefault(p => PathOperations.ArePathesEqual(moduleProjectPath, p.FullPath)) == null)
				//	{
				//		string details = string.Format("Project contains a module '{0}', but corresponding project hasn't been loaded", module.Path);
				//		var fix = new DelegatedFix
				//		{
				//			Title = "Try to load the module",
				//			DelegatedAction = () => _repository.LoadOneProject(moduleProjectPath)
				//		};
				//		var error = new ValidationError(project, "Module hasn't been loaded", details, ErrorLevel.Error);
				//		error.AddFix(fix);
				//		ValidationErrors.Add(error);
				//		continue;
				//	}
			}
		}
	}
}
