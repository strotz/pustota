using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class CiManagement {
        
		private string systemField;
        
		private string urlField;
        
		private Notifier[] notifiersField;
        
		/// <remarks/>
		public string system {
			get {
				return this.systemField;
			}
			set {
				this.systemField = value;
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
		[XmlArrayItem("notifier", IsNullable=false)]
		public Notifier[] notifiers {
			get {
				return this.notifiersField;
			}
			set {
				this.notifiersField = value;
			}
		}
	}
}