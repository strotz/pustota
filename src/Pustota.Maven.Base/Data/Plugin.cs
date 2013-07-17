using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	[Serializable]
	[System.Diagnostics.DebuggerStepThroughAttribute]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://maven.apache.org/POM/4.0.0")]
	public class Plugin : ProjectReferenceBase
	{
		public Plugin()
		{
			// GroupId = "org.apache.maven.plugins";
			Extensions = false;
			Dependencies = new List<Dependency>();
		}

		[XmlElement("extensions")]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool Extensions { get; set; }

		[XmlArray("executions")]
		[XmlArrayItem("execution", IsNullable = false)]
		public PluginExecution[] Executions { get; set; }

		[XmlArray("dependencies")]
		[XmlArrayItem("dependency", IsNullable = false)]
		public List<Dependency> Dependencies { get; set; }

		public bool ShouldSerializeDependencies()
		{
			return Dependencies != null && Dependencies.Count != 0;
		}

		public PluginGoals goals { get; set; }

		[XmlElement("inherited")]
		public string Inherited { get; set; }

		[XmlElement("configuration")]
		public PluginConfiguration Configuration { get; set; }
	}
}