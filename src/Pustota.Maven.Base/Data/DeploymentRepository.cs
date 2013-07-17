using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class DeploymentRepository {
        
		private bool uniqueVersionField;
        
		private string idField;
        
		private string nameField;
        
		private string urlField;
        
		private string layoutField;
        
		public DeploymentRepository() {
			this.uniqueVersionField = true;
			this.layoutField = "default";
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool uniqueVersion {
			get {
				return this.uniqueVersionField;
			}
			set {
				this.uniqueVersionField = value;
			}
		}
        
		/// <remarks/>
		public string id {
			get {
				return this.idField;
			}
			set {
				this.idField = value;
			}
		}
        
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
		[System.ComponentModel.DefaultValueAttribute("default")]
		public string layout {
			get {
				return this.layoutField;
			}
			set {
				this.layoutField = value;
			}
		}
	}
}