using System.Collections.Generic;

namespace Pustota.Maven.Models
{
	public interface IProjectQueries
	{
		IEnumerable<IModule> AllModules { get; }
		IEnumerable<IDependency> AllDependencies { get; }
		IEnumerable<IProperty> AllProperties { get; }
		IEnumerable<IPlugin> AllPlugins { get; }

		bool UsesProjectAs(IProjectReference projectReference, SearchOptions creteria);
	}
}