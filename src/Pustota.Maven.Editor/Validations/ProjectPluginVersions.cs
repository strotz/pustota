using System;
using System.Linq;
using Pustota.Maven.Editor.Externals;
using Pustota.Maven.Editor.Models;
using Pustota.Maven.Editor.Validations.Fixes;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Editor.Validations
{
	internal class ProjectPluginVersions :
		IValidation
	{
		private readonly IValidationOutput _validationOutput;
		private readonly ProjectNode _projectNode;
		private readonly IProjectsRepository _repository;
		private readonly ExternalModulesRepository _externalModules;

		public ProjectPluginVersions(IValidationOutput validationOutput, ProjectNode projectNode, IProjectsRepository repository, ExternalModulesRepository externalModules)
		{
			_validationOutput = validationOutput;
			_projectNode = projectNode;
			_repository = repository;
			_externalModules = externalModules;
		}

		public ValidationResult Validate()
		{
			foreach (IPlugin plugin in _projectNode
				.Project.AllPlugins.Where(
					p => p.HasSpecificVersion 
					&& !_repository.ContainsProject(p, true)
					&& !_externalModules.Contains(p, true)))
			{
				var error = new ValidationError(
					_projectNode.Project, "Project plugin error",
					ErrorLevel.Warning);

				var potencial = _repository.SelectProjectNodes(plugin, false).ToArray();
				if (potencial.Length == 0)
				{
					error.Details = string.Format("Project {0} uses undefined plugin {1}.", _projectNode.Project, plugin);
					error.AddFix(new AddToExternalFix(_externalModules, plugin));
				}
				else if (potencial.Length == 1)
				{
					error.Details = string.Format("Project {0} references different plugin version {1}.", _projectNode.Project, plugin);
					error.AddFix(new VersionFix(_projectNode.Project, plugin, potencial.Single().Version));
				}
				else
				{
					error.Details = string.Format("Project {0} references different plugin version {1}.", _projectNode.Project, plugin);
					foreach (var candicate in potencial)
					{
						error.AddFix(new VersionFix(_projectNode.Project, plugin, candicate.Version));
					}
				}

				_validationOutput.AddError(error);
			}
			return ValidationResult.Good;
		}
	}
}