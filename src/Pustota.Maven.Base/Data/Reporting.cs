using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class Reporting {
        
		private bool excludeDefaultsField;
        
		private string outputDirectoryField;
        
		private ReportPlugin[] pluginsField;
        
		public Reporting() {
			this.excludeDefaultsField = false;
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool excludeDefaults {
			get {
				return this.excludeDefaultsField;
			}
			set {
				this.excludeDefaultsField = value;
			}
		}
        
		/// <remarks/>
		public string outputDirectory {
			get {
				return this.outputDirectoryField;
			}
			set {
				this.outputDirectoryField = value;
			}
		}
        
		/// <remarks/>
		[XmlArrayItem("plugin", IsNullable=false)]
		public ReportPlugin[] plugins {
			get {
				return this.pluginsField;
			}
			set {
				this.pluginsField = value;
			}
		}
	}
}