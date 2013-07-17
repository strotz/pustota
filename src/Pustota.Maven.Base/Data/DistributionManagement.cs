using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class DistributionManagement {
        
		private DeploymentRepository repositoryField;
        
		private DeploymentRepository snapshotRepositoryField;
        
		private Site siteField;
        
		private string downloadUrlField;
        
		private Relocation relocationField;
        
		private string statusField;
        
		/// <remarks/>
		public DeploymentRepository repository {
			get {
				return this.repositoryField;
			}
			set {
				this.repositoryField = value;
			}
		}
        
		/// <remarks/>
		public DeploymentRepository snapshotRepository {
			get {
				return this.snapshotRepositoryField;
			}
			set {
				this.snapshotRepositoryField = value;
			}
		}
        
		/// <remarks/>
		public Site site {
			get {
				return this.siteField;
			}
			set {
				this.siteField = value;
			}
		}
        
		/// <remarks/>
		public string downloadUrl {
			get {
				return this.downloadUrlField;
			}
			set {
				this.downloadUrlField = value;
			}
		}
        
		/// <remarks/>
		public Relocation relocation {
			get {
				return this.relocationField;
			}
			set {
				this.relocationField = value;
			}
		}
        
		/// <remarks/>
		public string status {
			get {
				return this.statusField;
			}
			set {
				this.statusField = value;
			}
		}
	}
}