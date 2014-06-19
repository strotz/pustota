using System.Collections.Generic;

namespace Pustota.Maven.Models
{
	public interface IBuildContainer
	{
		List<IModule> Modules { get; set; }
		List<IDependency> Dependencies { get; set; }
		List<IProperty> Properties { get; set; }
		List<IPlugin> Plugins { get; set; }
		List<IPlugin> PluginManagement { get; set; }
	}
}