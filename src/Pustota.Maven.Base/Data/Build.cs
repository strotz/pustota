using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	[Serializable()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://maven.apache.org/POM/4.0.0")]
	public class Build
	{
		public Build()
		{
			Plugins = new List<Plugin>();
			PluginManagement = new PluginManagement();
		}

		/// <remarks/>
		public string sourceDirectory { get; set; }

		/// <remarks/>
		public string scriptSourceDirectory { get; set; }

		/// <remarks/>
		public string testSourceDirectory { get; set; }

		/// <remarks/>
		public string outputDirectory { get; set; }

		/// <remarks/>
		public string testOutputDirectory { get; set; }

		/// <remarks/>
		[XmlArrayItem("extension", IsNullable = false)]
		public Extension[] extensions { get; set; }

		/// <remarks/>
		public string defaultGoal { get; set; }

		/// <remarks/>
		[XmlArrayItem("resource", IsNullable = false)]
		public Resource[] resources { get; set; }

		/// <remarks/>
		[XmlArrayItem("testResource", IsNullable = false)]
		public Resource[] testResources { get; set; }

		/// <remarks/>
		public string directory { get; set; }

		/// <remarks/>
		public string finalName { get; set; }

		/// <remarks/>
		[XmlArrayItem("filter", IsNullable = false)]
		public string[] filters { get; set; }

		[XmlElement("pluginManagement")]
		public PluginManagement PluginManagement { get; set; }

		public bool ShouldSerializePluginManagement()
		{
			return PluginManagement != null && PluginManagement.Plugins.Count != 0;
		}

		[XmlArray("plugins")]
		[XmlArrayItem("plugin", IsNullable = false)]
		public List<Plugin> Plugins { get; set; }

		public bool ShouldSerializePlugins()
		{
			return Plugins != null && Plugins.Count != 0;
		}
	}
}