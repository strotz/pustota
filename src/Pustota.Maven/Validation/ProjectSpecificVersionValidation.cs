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
			if (!resolvedData.Version.IsDefined)
			{
				//	var error = new ValidationError(project, "Project does not have version", ErrorLevel.Error);
				//	error.Details = string.Format("Project {0} version is not specified of cannot be inherited from {1}", project, project.Parent);
				yield return new ValidationProblem("projectversionmustbe")
				{
					ProjectReference = project,
					Severity = ProblemSeverity.ProjectFatal,
					Description = "either version or parent version must be specified specified"
				};
			}
			else if (!project.Version.IsDefined)
			{
				yield return new ValidationProblem("explicitversion")
				{
					ProjectReference = project,
					Severity = ProblemSeverity.ProjectInfo,
					Description = "consider explicitly define project version"
				};
			}
		}
	}
}