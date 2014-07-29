using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ParentSpecificVersionValidation : IValidation
	{
		private readonly IProject _project;

		public ParentSpecificVersionValidation(IProject project) 
		{
			_project = project; 
		}

		public IEnumerable<ValidationProblem> Validate()
		{
			if (_project.Parent != null && !_project.Parent.ReferenceOperations().HasSpecificVersion)
			{
				// var error = new ValidationError(project, "Project parent error", ErrorLevel.Error);
				// TODO: if there is correct parent found via relativePath, and it has version (or resolvedVersion) - add fix
				// error.AddFix(GetParentVersionFix(project, parent, realParentVersion, MessageResources.FixParentToMatchSource));

				yield return new ValidationProblem()
				{
					Severity = ProblemSeverity.ProjectFatal,
					Description = string.Format("Project {0} does not have parent version specified.", _project)
				};
			}
		}
	}
}