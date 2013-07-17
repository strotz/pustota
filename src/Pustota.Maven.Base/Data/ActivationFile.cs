using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class ActivationFile {
        
		private string missingField;
        
		private string existsField;
        
		/// <remarks/>
		public string missing {
			get {
				return this.missingField;
			}
			set {
				this.missingField = value;
			}
		}
        
		/// <remarks/>
		public string exists {
			get {
				return this.existsField;
			}
			set {
				this.existsField = value;
			}
		}
	}
}