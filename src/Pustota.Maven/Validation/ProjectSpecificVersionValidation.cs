using System;
using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ProjectSpecificVersionValidation : 
		IValidation
	{
		private readonly IProject _project;

		public ProjectSpecificVersionValidation(IProject project)
		{
			_project = project;
		}

		public IEnumerable<ValidationProblem> Validate()
		{
			//if (_project.IsVersionUnresolved) 
			//{
			//	var error = new ValidationError(project, "Project does not have version", ErrorLevel.Error);
			//	error.Details = string.Format("Project {0} version is not specified of cannot be inherited from {1}", project, project.Parent);
			//	_validationOutput.AddError(error);
			//	return ValidationResult.ProjectWarning;
			//}

			throw new NotImplementedException();
		}
	}
}