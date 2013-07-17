using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	[Serializable]
	[System.Diagnostics.DebuggerStepThroughAttribute]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public class PluginManagement 
	{
		public PluginManagement()
		{
			Plugins = new List<Plugin>();	
		}

		[XmlArray("plugins")]
		[XmlArrayItem("plugin", IsNullable=false)]
		public List<Plugin> Plugins { get; set; }
	}
}