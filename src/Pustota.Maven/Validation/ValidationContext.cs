using Pustota.Maven.Externals;

namespace Pustota.Maven.Validation
{
	// REVIEW: it is not validation context, it looks like execution context
	public class ValidationContext
	{
		public IProjectsRepository Repository { get; set; }
		public IExternalModulesRepository ExternalModules { get; set; }
	}
}