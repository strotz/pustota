using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class Prerequisites {
        
		private string mavenField;
        
		public Prerequisites() {
			this.mavenField = "2.0";
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute("2.0")]
		public string maven {
			get {
				return this.mavenField;
			}
			set {
				this.mavenField = value;
			}
		}
	}
}