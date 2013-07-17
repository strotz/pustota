using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class Contributor {
        
		private string nameField;
        
		private string emailField;
        
		private string urlField;
        
		private string organizationField;
        
		private string organizationUrlField;
        
		private string[] rolesField;
        
		private string timezoneField;
        
		private ContributorProperties propertiesField;
        
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
		public string email {
			get {
				return this.emailField;
			}
			set {
				this.emailField = value;
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
		public string organization {
			get {
				return this.organizationField;
			}
			set {
				this.organizationField = value;
			}
		}
        
		/// <remarks/>
		public string organizationUrl {
			get {
				return this.organizationUrlField;
			}
			set {
				this.organizationUrlField = value;
			}
		}
        
		/// <remarks/>
		[XmlArrayItem("role", IsNullable=false)]
		public string[] roles {
			get {
				return this.rolesField;
			}
			set {
				this.rolesField = value;
			}
		}
        
		/// <remarks/>
		public string timezone {
			get {
				return this.timezoneField;
			}
			set {
				this.timezoneField = value;
			}
		}
        
		/// <remarks/>
		public ContributorProperties properties {
			get {
				return this.propertiesField;
			}
			set {
				this.propertiesField = value;
			}
		}
	}
}