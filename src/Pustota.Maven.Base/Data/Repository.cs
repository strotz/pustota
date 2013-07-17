using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class Repository {
        
		private RepositoryPolicy releasesField;
        
		private RepositoryPolicy snapshotsField;
        
		private string idField;
        
		private string nameField;
        
		private string urlField;
        
		private string layoutField;
        
		public Repository() {
			this.layoutField = "default";
		}
        
		/// <remarks/>
		public RepositoryPolicy releases {
			get {
				return this.releasesField;
			}
			set {
				this.releasesField = value;
			}
		}
        
		/// <remarks/>
		public RepositoryPolicy snapshots {
			get {
				return this.snapshotsField;
			}
			set {
				this.snapshotsField = value;
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