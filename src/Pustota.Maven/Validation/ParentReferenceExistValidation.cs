using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ParentReferenceExistValidation : IProjectValidator
	{
		public IEnumerable<IValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			var result = ValidateInternal(context, project);
			if (result != null)
			{
				yield return result;
			}
		}

		// REVIEW need logical refactoring
		private IValidationProblem ValidateInternal(IExecutionContext context, IProject project)
		{
			var parentReference = project.Parent;
			if (parentReference == null)
			{
				return null;
			}

			var extractor = new ProjectDataExtractor();

			IProject parentByPath;
			if (context.TryGetParentByPath(project, out parentByPath))
			{
				var resolved = extractor.Extract(parentByPath);
				if (project.Operations().HasProjectAsParent(resolved))
				{
					return null;
				}

				if (project.Operations().HasProjectAsParent(resolved, false))
				{
					return new ValidationProblem // TODO: fixable
					{
						Severity = ProblemSeverity.ProjectWarning,
						Description = string.Format("Version of parent reference {0} is different from actual parent {1}.", project.Parent, resolved)
					};
				}
			}

//			var validation = new ReferenceValidator(context);
//			return validation.ValidateReference(project, parentReference, "parent");

			var operation = parentReference.ReferenceOperations();
			var potencial = context.AllExtractedProjects.
				Where(p => operation.ReferenceEqualTo(p, false)).ToArray();

			if (potencial.Length == 0)
			{
				//	if (_externalModules.Contains(parent, true))
				//	{
				//		return ValidationResult.Good;
				//	}

				return new ValidationProblem // TODO: fixable
				{
					Severity = ProblemSeverity.ProjectWarning,
					Description = string.Format("Project {0} references unknown parent {1}", project, project.Parent)
				};
				// error.AddFix(new AddExternalModuleFix(_externalModules, parent));
			}

			var exact = potencial.SingleOrDefault(p => operation.VersionEqualTo(p.Version));
			if (exact != null)
			{
				return new ValidationProblem // TODO: fixable
				{
					Severity = ProblemSeverity.ProjectWarning,
					Description = string.Format("Project {0} has incorrect relative path ({2}) to parent {1}", project, project.Parent, project.Parent.RelativePath)
				};
			}
			if (potencial.Length == 1)
			{
				return new ValidationProblem // TODO: fixable
				{
					Severity = ProblemSeverity.ProjectWarning,
					Description = string.Format("Project {0} parent reference {1} is wrong. Found potencial candidate {2}", project, project.Parent, potencial.Single())
				};
				// error.AddFix(new ApplyVersionFix(_projectNode.Project, parent, potencial.Single().Version));
			}
			return new ValidationProblem // TODO: fixable
			{
				Severity = ProblemSeverity.ProjectWarning,
				Description = string.Format("Project {0} parent reference {1} is wrong. Found multiple potencial candidates", project, project.Parent)
			};
			//foreach (var candicate in potencial)
			//{
			//	error.AddFix(new ApplyVersionFix(_projectNode.Project, parent, candicate.Version));
			//}


		//	if (_repository.ContainsProject(parent, true))
		//	{
		//		var parentProject = _repository.SelectProjectNodes(parent, true).Single();
		//		string resolvedPathToParent = PathOperations.GetRelativePath(_projectNode.FullPath, parentProject.FullPath);
		//		resolvedPathToParent = PathOperations.Normalize(resolvedPathToParent);

		//		if (!string.Equals(_projectNode.RelativeParentPath, resolvedPathToParent, StringComparison.OrdinalIgnoreCase))
		//		{
		//			error.Details = string.Format("Parent path '{0}' does not point to {1}, should be {2}",
		//				_projectNode.RelativeParentPath, parentProject, resolvedPathToParent);

		//			error.AddFix(new RelativePathFix(project, resolvedPathToParent));
		//			_validationOutput.AddError(error);
		//		}
		}
	}
}