using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class Resource {
        
		private string targetPathField;
        
		private bool filteringField;
        
		private string directoryField;
        
		private string[] includesField;
        
		private string[] excludesField;
        
		public Resource() {
			this.filteringField = false;
		}
        
		/// <remarks/>
		public string targetPath {
			get {
				return this.targetPathField;
			}
			set {
				this.targetPathField = value;
			}
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool filtering {
			get {
				return this.filteringField;
			}
			set {
				this.filteringField = value;
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
		[XmlArrayItem("include", IsNullable=false)]
		public string[] includes {
			get {
				return this.includesField;
			}
			set {
				this.includesField = value;
			}
		}
        
		/// <remarks/>
		[XmlArrayItem("exclude", IsNullable=false)]
		public string[] excludes {
			get {
				return this.excludesField;
			}
			set {
				this.excludesField = value;
			}
		}
	}
}