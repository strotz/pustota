using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class Relocation {
        
		private string groupIdField;
        
		private string artifactIdField;
        
		private string versionField;
        
		private string messageField;
        
		/// <remarks/>
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
		public string message {
			get {
				return this.messageField;
			}
			set {
				this.messageField = value;
			}
		}
	}
}