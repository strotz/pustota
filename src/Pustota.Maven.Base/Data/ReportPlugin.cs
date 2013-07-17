using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class ReportPlugin {
        
		private string groupIdField;
        
		private string artifactIdField;
        
		private string versionField;
        
		private string inheritedField;
        
		private ReportPluginConfiguration configurationField;
        
		private ReportSet[] reportSetsField;
        
		public ReportPlugin() {
			this.groupIdField = "org.apache.maven.plugins";
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute("org.apache.maven.plugins")]
		public string groupId {
			get {
				return this.groupIdField;
			}
			set {
				this.groupIdField = value;
			}
		}
        
		/// <remarks/>
		public string artifactId {
			get {
				return this.artifactIdField;
			}
			set {
				this.artifactIdField = value;
			}
		}
        
		/// <remarks/>
		public string version {
			get {
				return this.versionField;
			}
			set {
				this.versionField = value;
			}
		}
        
		/// <remarks/>
		public string inherited {
			get {
				return this.inheritedField;
			}
			set {
				this.inheritedField = value;
			}
		}
        
		/// <remarks/>
		public ReportPluginConfiguration configuration {
			get {
				return this.configurationField;
			}
			set {
				this.configurationField = value;
			}
		}
        
		/// <remarks/>
		[XmlArrayItem("reportSet", IsNullable=false)]
		public ReportSet[] reportSets {
			get {
				return this.reportSetsField;
			}
			set {
				this.reportSetsField = value;
			}
		}
	}
}