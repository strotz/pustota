using System;
using System.Linq;
using Pustota.Maven.Editor.Externals;
using Pustota.Maven.Editor.Models;
using Pustota.Maven.Editor.Validations.Fixes;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Editor.Validations
{
	internal class ParentReferenceExist : IValidation
	{
		private readonly IValidationOutput _validationOutput;
		private readonly ProjectNode _projectNode;
		private readonly IProjectsRepository _repository;
		private readonly ExternalModulesRepository _externalModules;

		public ParentReferenceExist(ProjectsValidations validationOutput, ProjectNode projectNode, IProjectsRepository repository, ExternalModulesRepository externalModules)
		{
			_validationOutput = validationOutput;
			_projectNode = projectNode;
			_repository = repository;
			_externalModules = externalModules;
		}

		public ValidationResult Validate()
		{
			Project project = _projectNode.Project;
			IParentReference parent = project.Parent;

			if (parent == null)
			{
				return ValidationResult.Good;
			}

			var error = new ValidationError(_projectNode.Project, "Project parent error", ErrorLevel.Warning);

			if (_externalModules.Contains(parent, true))
			{
				return ValidationResult.Good;
			}

			if (_repository.ContainsProject(parent, true))
			{
				var parentProject = _repository.SelectProjectNodes(parent, true).Single();
				string resolvedPathToParent = PathOperations.GetRelativePath(_projectNode.FullPath, parentProject.FullPath);
				resolvedPathToParent = PathOperations.Normalize(resolvedPathToParent);

				if (!string.Equals(_projectNode.ParentPath, resolvedPathToParent, StringComparison.OrdinalIgnoreCase))
				{
					error.Details = string.Format("Parent path '{0}' does not point to {1}, should be {2}",
						_projectNode.ParentPath, parentProject, resolvedPathToParent);

					error.AddFix(new RelativePathFix(project, resolvedPathToParent));
					_validationOutput.AddError(error);
				}

				return ValidationResult.Good;
			}

			var potencial = _repository.SelectProjectNodes(parent, false).ToArray();
			if (potencial.Length == 0)
			{
				error.Details = string.Format("Project {0} rererences unknown parent {1}.", _projectNode, parent);
				error.AddFix(new AddToExternalFix(_externalModules, parent));

				// REVIEW: try to resolve via parent path
			}
			else if (potencial.Length == 1)
			{
				error.Details = string.Format("Project {0} references does not match actual version {1}.", _projectNode.Project, parent); // TODO: better message
				error.AddFix(new VersionFix(_projectNode.Project, parent, potencial.Single().Version));
			}
			else
			{
				error.Details = string.Format("Project {0} references different plugin version {1}.", _projectNode.Project, parent);
				foreach (var candicate in potencial)
				{
					error.AddFix(new VersionFix(_projectNode.Project, parent, candicate.Version));
				}
			}

			_validationOutput.AddError(error);
			return ValidationResult.Good;
		}
	}
}