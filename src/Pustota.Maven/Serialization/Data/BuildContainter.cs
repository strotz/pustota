using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	internal class BuildContainter : IBuildContainer
	{
		public List<IModule> Modules { get; set; }
		public List<IDependency> Dependencies { get; set; }
		public List<IProperty> Properties { get; set; }

		public List<IPlugin> Plugins { get; set; }
		public List<IPlugin> PluginManagement { get; set; }
	}
}