using System;
using System.Collections.Generic;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ProjectPluginVersions :
		IValidation
	{
		private readonly IProject _project;
		private readonly IProjectsRepository _repository;
		private readonly IExternalModulesRepository _externalModules;

		public ProjectPluginVersions(IProject project, IProjectsRepository repository, IExternalModulesRepository externalModules)
		{
			_project = project;
			_repository = repository;
			_externalModules = externalModules;
		}

		public IEnumerable<ValidationProblem> Validate()
		{
			//foreach (IPlugin plugin in _project.
			//	.Project.AllPlugins.Where(
			//		p => p.HasSpecificVersion 
			//		&& !_repository.ContainsProject(p, true)
			//		&& !_externalModules.Contains(p, true)))
			//{
			//	var error = new ValidationError(
			//		_projectNode.Project, "Project plugin error",
			//		ErrorLevel.Warning);

			//	var potencial = _repository.SelectProjectNodes(plugin, false).ToArray();
			//	if (potencial.Length == 0)
			//	{
			//		error.Details = string.Format("Project {0} uses undefined plugin {1}.", _projectNode.Project, plugin);
			//		error.AddFix(new AddToExternalFix(_externalModules, plugin));
			//	}
			//	else if (potencial.Length == 1)
			//	{
			//		error.Details = string.Format("Project {0} references different plugin version {1}.", _projectNode.Project, plugin);
			//		error.AddFix(new VersionFix(_projectNode.Project, plugin, potencial.Single().Version));
			//	}
			//	else
			//	{
			//		error.Details = string.Format("Project {0} references different plugin version {1}.", _projectNode.Project, plugin);
			//		foreach (var candicate in potencial)
			//		{
			//			error.AddFix(new VersionFix(_projectNode.Project, plugin, candicate.Version));
			//		}
			//	}

			//	_validationOutput.AddError(error);
			//}
			//return ValidationResult.Good;

			yield break;
		}
	}
}