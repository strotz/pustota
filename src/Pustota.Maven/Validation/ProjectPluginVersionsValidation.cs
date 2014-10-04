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
		public IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			foreach (var plugin in project.Operations().AllPlugins.Where(p => p.Version.IsDefined))
			{
				//		&& !_externalModules.Contains(p, true)))
				// TODO: inherit plugin version
				var validation = new ReferenceValidator(context);
				var result = validation.ValidateReference(project, plugin, "plugin");
				if (result != null)
				{
					yield return result;
				}
			}
		}
	}
}