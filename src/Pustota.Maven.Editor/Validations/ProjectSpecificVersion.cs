using Pustota.Maven.Editor.Models;

namespace Pustota.Maven.Editor.Validations
{
	internal class ProjectSpecificVersion : 
		IValidation
	{
		private readonly IValidationOutput _validationOutput;
		private readonly ProjectNode _projectNode;

		public ProjectSpecificVersion(IValidationOutput validationOutput, ProjectNode projectNode)
		{
			_validationOutput = validationOutput;
			_projectNode = projectNode;
		}

		public ValidationResult Validate()
		{
			var project = _projectNode.Project;
			if (_projectNode.IsVersionUnresolved) 
			{
				var error = new ValidationError(project, "Project does not have version", ErrorLevel.Error);
				error.Details = string.Format("Project {0} version is not specified of cannot be inherited from {1}", project, project.Parent);
				_validationOutput.AddError(error);
				return ValidationResult.ProjectWarning;
			}

			return ValidationResult.Good;
		}
	}
}