using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	[Serializable]
	[System.Diagnostics.DebuggerStepThroughAttribute]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://maven.apache.org/POM/4.0.0")]
	public class Profile
	{
		public Profile()
		{
			Modules = new List<Module>();
			Dependencies = new List<Dependency>();
			Properties = new Properties();
		}

		[XmlElement("id")]
		public string Id { get; set; }

		[XmlElement("activation")]
		public Activation Activation { get; set; }

		/// <remarks/>
		public BuildBase build { get; set; }

		[XmlArray("modules")]
		[XmlArrayItem("module", IsNullable = false)]
		public List<Module> Modules { get; set; }

		public bool ShouldSerializeModules()
		{
			return Modules != null && Modules.Count != 0;
		}

		/// <remarks/>
		[XmlArrayItem("repository", IsNullable = false)]
		public Repository[] repositories { get; set; }

		/// <remarks/>
		[XmlArrayItem("pluginRepository", IsNullable = false)]
		public Repository[] pluginRepositories { get; set; }

		[XmlArray("dependencies")]
		[XmlArrayItem("dependency", IsNullable = false)]
		public List<Dependency> Dependencies { get; set; }

		public bool ShouldSerializeDependencies()
		{
			return Dependencies != null && Dependencies.Count != 0;
		}

		/// <remarks/>
		public ProfileReports reports { get; set; }

		/// <remarks/>
		public Reporting reporting { get; set; }

		/// <remarks/>
		public DependencyManagement dependencyManagement { get; set; }

		/// <remarks/>
		public DistributionManagement distributionManagement { get; set; }

		[XmlElement("properties")]
		public Properties Properties { get; set; }
	}
}