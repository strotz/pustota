using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class Scm {
        
		private string connectionField;
        
		private string developerConnectionField;
        
		private string tagField;
        
		private string urlField;
        
		public Scm() {
			this.tagField = "HEAD";
		}
        
		/// <remarks/>
		public string connection {
			get {
				return this.connectionField;
			}
			set {
				this.connectionField = value;
			}
		}
        
		/// <remarks/>
		public string developerConnection {
			get {
				return this.developerConnectionField;
			}
			set {
				this.developerConnectionField = value;
			}
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute("HEAD")]
		public string tag {
			get {
				return this.tagField;
			}
			set {
				this.tagField = value;
			}
		}
        
		/// <remarks/>
		public string url {
			get {
				return this.urlField;
			}
			set {
				this.urlField = value;
			}
		}
	}
}