using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class ReportSet {
        
		private string idField;
        
		private ReportSetConfiguration configurationField;
        
		private string inheritedField;
        
		private string[] reportsField;
        
		public ReportSet() {
			this.idField = "default";
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute("default")]
		public string id {
			get {
				return this.idField;
			}
			set {
				this.idField = value;
			}
		}
        
		/// <remarks/>
		public ReportSetConfiguration configuration {
			get {
				return this.configurationField;
			}
			set {
				this.configurationField = value;
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
		[XmlArrayItem("report", IsNullable=false)]
		public string[] reports {
			get {
				return this.reportsField;
			}
			set {
				this.reportsField = value;
			}
		}
	}
}