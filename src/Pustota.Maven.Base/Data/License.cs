using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class License {
        
		private string nameField;
        
		private string urlField;
        
		private string distributionField;
        
		private string commentsField;
        
		/// <remarks/>
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
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
        
		/// <remarks/>
		public string distribution {
			get {
				return this.distributionField;
			}
			set {
				this.distributionField = value;
			}
		}
        
		/// <remarks/>
		public string comments {
			get {
				return this.commentsField;
			}
			set {
				this.commentsField = value;
			}
		}
	}
}