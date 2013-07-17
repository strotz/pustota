using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(AnonymousType=true, Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class DeveloperProperties {
        
		private System.Xml.XmlElement[] anyField;
        
		/// <remarks/>
		[XmlAnyElement()]
		public System.Xml.XmlElement[] Any {
			get {
				return this.anyField;
			}
			set {
				this.anyField = value;
			}
		}
	}
}