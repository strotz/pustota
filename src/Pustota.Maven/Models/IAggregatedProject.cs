using System.Collections.Generic;

namespace Pustota.Maven.Models
{
	public interface IAggregatedProject
	{
		IEnumerable<IModule> AllModules { get; }
		IEnumerable<IDependency> AllDependencies { get; }
		IEnumerable<IProperty> AllProperties { get; }
		IEnumerable<IPlugin> AllPlugins { get; }
	}
}