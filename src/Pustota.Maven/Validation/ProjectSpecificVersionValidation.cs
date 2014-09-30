using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ProjectSpecificVersionValidation : 
		IProjectValidator
	{
		public IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			var resolvedData = new ProjectDataExtractor().Extract(project);
			if (string.IsNullOrEmpty(resolvedData.Version)) // REVIEW: class for Version
			{
				//	var error = new ValidationError(project, "Project does not have version", ErrorLevel.Error);
				//	error.Details = string.Format("Project {0} version is not specified of cannot be inherited from {1}", project, project.Parent);
				yield return new ValidationProblem
				{
					ProjectReference = project,
					Severity = ProblemSeverity.ProjectFatal,
					Description = string.Format("either version or parent version must be specified specified")
				};
			}
		}
	}
}