using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ParentReferenceExistValidation : IProjectValidator
	{
		public IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			var result = ValidateInternal(context, project);
			if (result != null)
			{
				yield return result;
			}
		}

		// REVIEW need logical refactoring
		private IProjectValidationProblem ValidateInternal(IExecutionContext context, IProject project)
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
					return new ValidationProblem("actualparentversion") // TODO: fixable
					{
						ProjectReference = project,
						Severity = ProblemSeverity.ProjectWarning,
						Description = string.Format("parent reference version {0} is different from actual parent {1}.", project.Parent, resolved)
					};
				}
			}

			var validation = new ReferenceValidator(context);
			var result = validation.ValidateReference(project, parentReference, "parent");
			if (result != null)
			{
				return result;
			}
			// exact match found, but path is wrong
			return new ValidationProblem("parentpath") // TODO: fixable
			{
				ProjectReference = project,
				Severity = ProblemSeverity.ProjectWarning,
				Description = string.Format("incorrect relative path ({1}) to parent {0}", project.Parent, project.Parent.RelativePath)
			};

		//		var parentProject = _repository.SelectProjectNodes(parent, true).Single();
		//		string resolvedPathToParent = PathOperations.GetRelativePath(_projectNode.FullPath, parentProject.FullPath);
		//		resolvedPathToParent = PathOperations.Normalize(resolvedPathToParent);

		//		if (!string.Equals(_projectNode.RelativeParentPath, resolvedPathToParent, StringComparison.OrdinalIgnoreCase))
		//		{
		//			error.Details = string.Format("Parent path '{0}' does not point to {1}, should be {2}",
		//				_projectNode.RelativeParentPath, parentProject, resolvedPathToParent);

		//			error.AddFix(new RelativePathFix(project, resolvedPathToParent));
		//			_validationOutput.AddError(error);
		}
	}
}