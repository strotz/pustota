using System.Collections.Generic;
using System.Xml.Serialization;

namespace Pustota.Maven.Base
{
	public class Build
	{
		public Build()
		{
			Plugins = new List<Plugin>();
			PluginManagement = new List<Plugin>();
		}

		[XmlArray("plugins")]
		[XmlArrayItem("plugin")]
		public List<Plugin> Plugins { get; set; }

		public bool ShouldSerializePlugins()
		{
			return Plugins != null && Plugins.Count != 0;
		}

		[XmlArray("pluginManagement")]
		[XmlArrayItem("plugin")]
		public List<Plugin> PluginManagement { get; set; }

		public bool ShouldSerializePluginManagement()
		{
			return PluginManagement != null && PluginManagement.Count != 0;
		}

		public bool ShouldSerializeMe()
		{
			return ShouldSerializePlugins() || ShouldSerializePluginManagement();
		}
	}
}