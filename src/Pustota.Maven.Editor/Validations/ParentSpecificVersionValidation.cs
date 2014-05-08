using Pustota.Maven.Editor.Models;

namespace Pustota.Maven.Editor.Validations
{
	internal class ParentSpecificVersionValidation : IValidation
	{
		private readonly IValidationOutput _validationOutput;
		private readonly ProjectNode _projectNode;

		public ParentSpecificVersionValidation(IValidationOutput validationOutput, ProjectNode projectNode) 
		{
			_validationOutput = validationOutput;
			_projectNode = projectNode; 
		}

		public ValidationResult Validate()
		{
			var project = _projectNode.Project;
			if (project.Parent != null && !project.Parent.HasSpecificVersion)
			{
				var error = new ValidationError(project, "Project parent error", ErrorLevel.Error);
				error.Details = string.Format("Project {0} does not have parent version specified.", project);
				_validationOutput.AddError(error);

				// TODO: if there is correct parent found via relativePath, and it has version (or resolvedVersion) - add fix
				// error.AddFix(GetParentVersionFix(project, parent, realParentVersion, MessageResources.FixParentToMatchSource));

				return ValidationResult.ProjectFatal;
			}

			return ValidationResult.Good;
		}
	}
}