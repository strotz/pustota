using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	class ProjectDependencyValidation : IProjectValidator
	{
		public IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			foreach (IDependency dependency in project.Operations().AllDependencies)
			{
				if (dependency.ReferenceOperations().IsSnapshot && !project.ReferenceOperations().IsSnapshot)
				{
					yield return new ValidationProblem
					{
						ProjectReference = project,
						Severity = ProblemSeverity.ProjectWarning,
						Description = string.Format("release depends on SNAPSHOT {0}", dependency)
					};
				}

				var result = ValidateDependency(context, project, dependency);
				if (result != null)
				{
					yield return result;
				}

				//	var dependencyProject = potencial.Single();
				//	string realDependencyVersion = dependencyProject.Version;


				//	if (!string.IsNullOrEmpty(realDependencyVersion) && realDependencyVersion != dependencyReference.Version)
				//	{
				//		error.Details = string.Format("Project {0} depends on {1} but tree contains {2}.", 
				//			projectNode.Project, dependencyReference, dependencyProject);

				//		error.AddFix(new ApplyVersionFix(projectNode.Project, dependencyReference, realDependencyVersion));
				//		ValidationErrors.Add(error);
				//	}
			}
		}

		private IProjectValidationProblem ValidateDependency(IExecutionContext context, IProject project, IDependency dependency)
		{
			IProjectReferenceOperations operation = dependency.ReferenceOperations();

			if (operation.HasSpecificVersion) // REVIEW: inhereited too
			{
				var validation = new ReferenceValidator(context);
				return validation.ValidateReference(project, dependency, "dependency");
			}
			else
			{
				// REVIEW: apply inheritance and dependencyManagement 
				//		error.Level = ErrorLevel.Warning;
				//		error.Details =  string.Format("Project {0} depends on {1}:{2} has no version specified.", 
				//			projectNode.Project, dependencyReference.GroupId, dependencyReference.ArtifactId);
				//		error.AddFix(new ApplyVersionFix(projectNode.Project, dependencyReference, realDependencyVersion));
				//		AddError(error);
				//		continue;

				return null;
			}
		}
	}
}