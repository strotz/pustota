using System;
using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ProjectSpecificVersionValidation : 
		IProjectValidator
	{
		public IEnumerable<ValidationProblem> Validate(IValidationContext context, IProject project)
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