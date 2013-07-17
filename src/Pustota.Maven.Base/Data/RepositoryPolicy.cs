using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class RepositoryPolicy {
        
		private bool enabledField;
        
		private string updatePolicyField;
        
		private string checksumPolicyField;
        
		public RepositoryPolicy() {
			this.enabledField = true;
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool enabled {
			get {
				return this.enabledField;
			}
			set {
				this.enabledField = value;
			}
		}
        
		/// <remarks/>
		public string updatePolicy {
			get {
				return this.updatePolicyField;
			}
			set {
				this.updatePolicyField = value;
			}
		}
        
		/// <remarks/>
		public string checksumPolicy {
			get {
				return this.checksumPolicyField;
			}
			set {
				this.checksumPolicyField = value;
			}
		}
	}
}