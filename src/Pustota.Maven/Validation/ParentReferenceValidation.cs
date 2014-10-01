using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ParentReferenceValidation : IProjectValidator
	{
		public IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			if (project.Parent != null)
			{
				if (project.Parent.ReferenceOperations().IsEmpty)
				{
					// TODO: potencially fixable
					// var error = new ValidationError(project, "Project parent error", ErrorLevel.Error);
					// TODO: if there is correct parent found via relativePath, and it has version (or resolvedVersion) - add fix
					// error.AddFix(GetParentVersionFix(project, parent, realParentVersion, MessageResources.FixParentToMatchSource));
					yield return new ValidationProblem("parentartifactid")
					{
						ProjectReference = project,
						Severity = ProblemSeverity.ProjectFatal,
						Description = string.Format("parent artifactId not specified")
					};
				}
			}
		}
	}
}