using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class PluginExecution {
        
		private string idField;
        
		private string phaseField;
        
		private string[] goalsField;
        
		private string inheritedField;
        
		private PluginExecutionConfiguration configurationField;
        
		public PluginExecution() {
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
		public string phase {
			get {
				return this.phaseField;
			}
			set {
				this.phaseField = value;
			}
		}
        
		/// <remarks/>
		[XmlArrayItem("goal", IsNullable=false)]
		public string[] goals {
			get {
				return this.goalsField;
			}
			set {
				this.goalsField = value;
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
		public PluginExecutionConfiguration configuration {
			get {
				return this.configurationField;
			}
			set {
				this.configurationField = value;
			}
		}
	}
}