using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	public interface IProject : IProjectReference
	{
		[XmlArray("modules")]
		[XmlArrayItem("module", IsNullable = false)]
		List<Module> Modules { get; set; }
	}

	[System.SerializableAttribute]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://maven.apache.org/POM/4.0.0")]
	[XmlRoot("project", Namespace = "http://maven.apache.org/POM/4.0.0", IsNullable = false)]
	public class Project : ProjectReferenceBase, IProject
	{
		[XmlAttribute("schemaLocation", Namespace = XmlSchema.InstanceNamespace)]
		public string SchemaLocation = "http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd";

		public Project()
		{
			Packaging = "jar";
			Modules = new List<Module>();
			Properties = new Properties();
			Dependencies = new List<Dependency>();
			Profiles = new List<Profile>();
			Repositories = new List<Repository>();
			PluginRepositories = new List<Repository>();
		}

		[XmlElement("parent")]
		public Parent Parent { get; set; }

		[XmlElement("modelVersion")]
		public string ModelVersion { get; set; }

		[XmlElement("packaging")]
		[System.ComponentModel.DefaultValueAttribute("jar")]
		public string Packaging { get; set; }

		[XmlElement("name")]
		public string Name { get; set; }

		/// <remarks/>
		public string description { get; set; }

		/// <remarks/>
		public string url { get; set; }

		/// <remarks/>
		public Prerequisites prerequisites { get; set; }

		/// <remarks/>
		public IssueManagement issueManagement { get; set; }

		/// <remarks/>
		public CiManagement ciManagement { get; set; }

		/// <remarks/>
		public string inceptionYear { get; set; }

		/// <remarks/>
		[XmlArrayItem("mailingList", IsNullable = false)]
		public MailingList[] mailingLists { get; set; }

		/// <remarks/>
		[XmlArrayItem("developer", IsNullable = false)]
		public Developer[] developers { get; set; }

		/// <remarks/>
		[XmlArrayItem("contributor", IsNullable = false)]
		public Contributor[] contributors { get; set; }

		/// <remarks/>
		[XmlArrayItem("license", IsNullable = false)]
		public License[] licenses { get; set; }

		/// <remarks/>
		public Scm scm { get; set; }

		/// <remarks/>
		public Organization organization { get; set; }

		public void EnableBuild()
		{
			if (Build == null)
			{
				Build = new Build();
			}
		}

		[XmlElement("build")]
		public Build Build { get; set; }

		[XmlArray("profiles")]
		[XmlArrayItem("profile", IsNullable = false)]
		public List<Profile> Profiles { get; set; }

		public bool ShouldSerializeProfiles()
		{
			return Profiles != null && Profiles.Count != 0;
		}

		[XmlArray("modules")]
		[XmlArrayItem("module", IsNullable = false)]
		public List<Module> Modules { get; set; }
		public bool ShouldSerializeModules()
		{
			return Modules != null && Modules.Count != 0;
		}

		[XmlArray("repositories"), XmlArrayItem("repository", IsNullable = false)]
		public List<Repository> Repositories { get; set; }
		public bool ShouldSerializeRepositories()
		{
			return Repositories != null && Repositories.Count != 0;
		}

		/// <remarks/>
		[XmlArray("pluginRepositories"), XmlArrayItem("pluginRepository", IsNullable = false)]
		public List<Repository> PluginRepositories { get; set; }
		public bool ShouldSerializePluginRepositories()
		{
			return PluginRepositories != null && PluginRepositories.Count != 0;
		}

		[XmlArray("dependencies"), XmlArrayItem("dependency", IsNullable = false)]
		public List<Dependency> Dependencies { get; set; }
		public bool ShouldSerializeDependencies()
		{
			return Dependencies != null && Dependencies.Count != 0;
		}

		/// <remarks/>
		public ModelReports reports { get; set; }

		/// <remarks/>
		public Reporting reporting { get; set; }

		/// <remarks/>
		public DependencyManagement dependencyManagement { get; set; }

		/// <remarks/>
		public DistributionManagement distributionManagement { get; set; }

		[XmlElement("properties")]
		public Properties Properties { get; set; }

		public bool ShouldSerializeProperties()
		{
			return Properties != null && !Properties.Empty;
		}
	}
}
