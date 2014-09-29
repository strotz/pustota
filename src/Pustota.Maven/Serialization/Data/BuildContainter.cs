using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	class BuildContainter : IBuildContainer
	{
		public List<IModule> Modules { get; set; }
		public List<IDependency> Dependencies { get; set; }
		public List<IDependency> DependencyManagement { get; set; }
		public List<IProperty> Properties { get; set; }
		public List<IPlugin> Plugins { get; set; }
		public List<IPlugin> PluginManagement { get; set; }

		public BuildContainter()
		{
			Modules = new List<IModule>();
			Properties = new List<IProperty>();
			Dependencies = new List<IDependency>();
			DependencyManagement = new List<IDependency>();
			Plugins = new List<IPlugin>();
			PluginManagement = new List<IPlugin>();
		}
	}
}