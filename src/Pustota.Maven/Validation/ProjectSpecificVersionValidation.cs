using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ProjectSpecificVersionValidation : 
		IProjectValidator
	{
		public IEnumerable<ValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			var resolvedData = context.GetResolvedData(project);
			if (string.IsNullOrEmpty(resolvedData.Version)) // REVIEW: class for Version
			{
				//	var error = new ValidationError(project, "Project does not have version", ErrorLevel.Error);
				//	error.Details = string.Format("Project {0} version is not specified of cannot be inherited from {1}", project, project.Parent);
				yield return new ValidationProblem
				{
					Severity = ProblemSeverity.ProjectFatal,
					Description = string.Format("Project {0} does not have version or parent version specified.", project)
				};
			}
		}
	}
}