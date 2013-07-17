using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class BuildBase {
        
		private string defaultGoalField;
        
		private Resource[] resourcesField;
        
		private Resource[] testResourcesField;
        
		private string directoryField;
        
		private string finalNameField;
        
		private string[] filtersField;
        
		private PluginManagement pluginManagementField;
        
		private Plugin[] pluginsField;
        
		/// <remarks/>
		public string defaultGoal {
			get {
				return this.defaultGoalField;
			}
			set {
				this.defaultGoalField = value;
			}
		}
        
		/// <remarks/>
		[XmlArrayItem("resource", IsNullable=false)]
		public Resource[] resources {
			get {
				return this.resourcesField;
			}
			set {
				this.resourcesField = value;
			}
		}
        
		/// <remarks/>
		[XmlArrayItem("testResource", IsNullable=false)]
		public Resource[] testResources {
			get {
				return this.testResourcesField;
			}
			set {
				this.testResourcesField = value;
			}
		}
        
		/// <remarks/>
		public string directory {
			get {
				return this.directoryField;
			}
			set {
				this.directoryField = value;
			}
		}
        
		/// <remarks/>
		public string finalName {
			get {
				return this.finalNameField;
			}
			set {
				this.finalNameField = value;
			}
		}
        
		/// <remarks/>
		[XmlArrayItem("filter", IsNullable=false)]
		public string[] filters {
			get {
				return this.filtersField;
			}
			set {
				this.filtersField = value;
			}
		}
        
		/// <remarks/>
		public PluginManagement pluginManagement {
			get {
				return this.pluginManagementField;
			}
			set {
				this.pluginManagementField = value;
			}
		}
        
		/// <remarks/>
		[XmlArrayItem("plugin", IsNullable=false)]
		public Plugin[] plugins {
			get {
				return this.pluginsField;
			}
			set {
				this.pluginsField = value;
			}
		}
	}
}