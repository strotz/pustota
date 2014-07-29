using System;
using System.Collections.Generic;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;
using Pustota.Maven.Validation.Fixes;

namespace Pustota.Maven.Editor.Validations
{
	class ProjectDependencyValidation : IValidation
	{
		public IEnumerable<ValidationProblem> Validate()
		{
			//foreach (IDependency dependencyReference in project.AllDependencies)
			//{
			//	var error = new ValidationError(projectNode.Project, "Project dependency error", ErrorLevel.Error);
			//	if (dependencyReference.HasSpecificVersion && _repository.ContainsProject(dependencyReference, true)) // REVIEW: inhereited too
			//	{
			//		if (!projectNode.IsSnapshot && dependencyReference.IsSnapshot())
			//		{
			//			error.Details = string.Format("Release project {0} depends on SNAPSHOT project {1}.", project, dependencyReference);
			//			error.AddFix(new SwitchToSnapshotFix(_repository, projectNode));
			//			AddError(error);
			//		}
			//		continue; // found, nothing to validate
			//	}
			//	var potencial = _repository.SelectProjectNodes(dependencyReference, false).ToArray();
			//	if (potencial.Length == 0)
			//	{
			//		if (!IsDependencyIgnored(dependencyReference)) // TODO: should we ignore specific version???
			//		{
			//			error.Details = string.Format("Project {0} dependency {1} not resolved.", projectNode.Project, dependencyReference);
			//			error.AddFix(new AddExternalModuleFix(_externalModules, dependencyReference));
			//			ValidationErrors.Add(error);
			//		}
			//		continue;
			//	}
			//	if (potencial.Length > 1)
			//	{
			//		error.Details = string.Format("Project {0} dependency {1} not resolved. Multiple corresponding projects found.", projectNode.Project, dependencyReference);
			//		foreach (var candicate in potencial)
			//		{
			//			error.AddFix(new ApplyVersionFix(projectNode.Project, dependencyReference, candicate.Version));
			//		}
			//		AddError(error);
			//		continue;
			//	}

			//	var dependencyProject = potencial.Single();
			//	string realDependencyVersion = dependencyProject.Version;

			//	if (!dependencyReference.HasSpecificVersion)
			//	{
			//		error.Level = ErrorLevel.Warning;
			//		error.Details =  string.Format("Project {0} depends on {1}:{2} has no version specified.", 
			//			projectNode.Project, dependencyReference.GroupId, dependencyReference.ArtifactId);
			//		error.AddFix(new ApplyVersionFix(projectNode.Project, dependencyReference, realDependencyVersion));
			//		AddError(error);
			//		continue;
			//	}

			//	if (!string.IsNullOrEmpty(realDependencyVersion) && realDependencyVersion != dependencyReference.Version)
			//	{
			//		error.Details = string.Format("Project {0} depends on {1} but tree contains {2}.", 
			//			projectNode.Project, dependencyReference, dependencyProject);

			//		error.AddFix(new ApplyVersionFix(projectNode.Project, dependencyReference, realDependencyVersion));
			//		ValidationErrors.Add(error);
			//	}
			//}

			throw new NotImplementedException();
		}
	}
}