using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class DependencyManagement {
        
		private Dependency[] dependenciesField;
        
		/// <remarks/>
		[XmlArrayItem("dependency", IsNullable=false)]
		public Dependency[] dependencies {
			get {
				return this.dependenciesField;
			}
			set {
				this.dependenciesField = value;
			}
		}
	}
}