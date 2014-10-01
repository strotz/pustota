using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ParentSpecificVersionValidation : IProjectValidator
	{
		public IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			if (project.Parent != null) 
			{
				if (!project.Parent.ReferenceOperations().HasSpecificVersion)
				{
					// var error = new ValidationError(project, "Project parent error", ErrorLevel.Error);
					// TODO: if there is correct parent found via relativePath, and it has version (or resolvedVersion) - add fix
					// error.AddFix(GetParentVersionFix(project, parent, realParentVersion, MessageResources.FixParentToMatchSource));
					yield return new ValidationProblem("parentversion") 
					{
						ProjectReference = project,
						Severity = ProblemSeverity.ProjectFatal,
						Description = string.Format("parent version not specified")
					};
				}
			}
		}
	}
}