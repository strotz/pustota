using System.Collections.Generic;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	// REVIEW: it is not validation context, it looks like execution context - still need some clarifications

	public interface IValidationContext
	{
		IEnumerable<IProject> AllProjects { get; }
		// REVIEW: do we need it now? IExternalModulesRepository ExternalModules { get; }
	}
}