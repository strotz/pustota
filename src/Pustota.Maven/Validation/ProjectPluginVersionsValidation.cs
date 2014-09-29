using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ProjectPluginVersionsValidation :
		IProjectValidator
	{
		public IEnumerable<IValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			foreach (var plugin in project.Operations().AllPlugins.Where(p => p.ReferenceOperations().HasSpecificVersion))
			{
				//		&& !_externalModules.Contains(p, true)))
				var result = ValidatePlugin(context, project, plugin);
				if (result != null)
				{
					yield return result;
				}
			}
		}

		private IValidationProblem ValidatePlugin(IExecutionContext context, IProject project, IPlugin plugin)
		{
			var operation = plugin.ReferenceOperations();

			var potencial = context.AllExtractedProjects. // TODO: context.AllProjects.Select(extractor.Extract) to context
				Where(p => operation.ReferenceEqualTo(p, false)).ToArray();

			if (potencial.Length == 0)
			{
				return new ValidationProblem // TODO: fixable
				{
					Severity = ProblemSeverity.ProjectWarning,
					Description = string.Format("Project {0} uses unknown plugin {1}", project, plugin)
				};
				//		error.AddFix(new AddExternalModuleFix(_externalModules, plugin));
			}

			var exact = potencial.SingleOrDefault(p => operation.VersionEqualTo(p.Version));
			if (exact != null)
			{
				return null;
			}

			if (potencial.Length == 1)
			{
				return new ValidationProblem // TODO: fixable
				{
					Severity = ProblemSeverity.ProjectWarning,
					Description = string.Format("Project {0} uses different plugin version {1}", project, plugin)
				};
				//		error.AddFix(new ApplyVersionFix(_projectNode.Project, plugin, potencial.Single().Version));
			}
			return new ValidationProblem // TODO: fixable
			{
				Severity = ProblemSeverity.ProjectWarning,
				Description = string.Format("Project {0} plugin version {1} is wrong. Found multiple potencial candidates", project, plugin)
			};
			//		foreach (var candicate in potencial)
			//		{
			//			error.AddFix(new ApplyVersionFix(_projectNode.Project, plugin, candicate.Version));
			//		}
		}
	}
}