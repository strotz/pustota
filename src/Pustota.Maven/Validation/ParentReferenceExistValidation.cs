using System;
using System.Collections.Generic;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ParentReferenceExistValidation : IProjectValidator
	{
		public IEnumerable<ValidationProblem> Validate(IValidationContext context, IProject project)
		{
			if (project.Parent == null)
			{
				yield break;
			}

		//	var error = new ValidationError(_projectNode.Project, "Project parent error", ErrorLevel.Warning);

		//	if (_externalModules.Contains(parent, true))
		//	{
		//		return ValidationResult.Good;
		//	}

		//	if (_repository.ContainsProject(parent, true))
		//	{
		//		var parentProject = _repository.SelectProjectNodes(parent, true).Single();
		//		string resolvedPathToParent = PathOperations.GetRelativePath(_projectNode.FullPath, parentProject.FullPath);
		//		resolvedPathToParent = PathOperations.Normalize(resolvedPathToParent);

		//		if (!string.Equals(_projectNode.ParentPath, resolvedPathToParent, StringComparison.OrdinalIgnoreCase))
		//		{
		//			error.Details = string.Format("Parent path '{0}' does not point to {1}, should be {2}",
		//				_projectNode.ParentPath, parentProject, resolvedPathToParent);

		//			error.AddFix(new RelativePathFix(project, resolvedPathToParent));
		//			_validationOutput.AddError(error);
		//		}

		//		return ValidationResult.Good;
		//	}

		//	var potencial = _repository.SelectProjectNodes(parent, false).ToArray();
		//	if (potencial.Length == 0)
		//	{
		//		error.Details = string.Format("Project {0} rererences unknown parent {1}.", _projectNode, parent);
		//		error.AddFix(new AddExternalModuleFix(_externalModules, parent));

		//		// REVIEW: try to resolve via parent path
		//	}
		//	else if (potencial.Length == 1)
		//	{
		//		error.Details = string.Format("Project {0} references does not match actual version {1}.", _projectNode.Project, parent); // TODO: better message
		//		error.AddFix(new ApplyVersionFix(_projectNode.Project, parent, potencial.Single().Version));
		//	}
		//	else
		//	{
		//		error.Details = string.Format("Project {0} references different plugin version {1}.", _projectNode.Project, parent);
		//		foreach (var candicate in potencial)
		//		{
		//			error.AddFix(new ApplyVersionFix(_projectNode.Project, parent, candicate.Version));
		//		}
		//	}

		//	_validationOutput.AddError(error);
		//	return ValidationResult.Good;

			throw new NotImplementedException();
		}
	}
}