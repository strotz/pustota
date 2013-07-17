using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class ActivationOS {
        
		private string nameField;
        
		private string familyField;
        
		private string archField;
        
		private string versionField;
        
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
		public string family {
			get {
				return this.familyField;
			}
			set {
				this.familyField = value;
			}
		}
        
		/// <remarks/>
		public string arch {
			get {
				return this.archField;
			}
			set {
				this.archField = value;
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
	}
}