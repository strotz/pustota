using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class MailingList {
        
		private string nameField;
        
		private string subscribeField;
        
		private string unsubscribeField;
        
		private string postField;
        
		private string archiveField;
        
		private string[] otherArchivesField;
        
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
		public string subscribe {
			get {
				return this.subscribeField;
			}
			set {
				this.subscribeField = value;
			}
		}
        
		/// <remarks/>
		public string unsubscribe {
			get {
				return this.unsubscribeField;
			}
			set {
				this.unsubscribeField = value;
			}
		}
        
		/// <remarks/>
		public string post {
			get {
				return this.postField;
			}
			set {
				this.postField = value;
			}
		}
        
		/// <remarks/>
		public string archive {
			get {
				return this.archiveField;
			}
			set {
				this.archiveField = value;
			}
		}
        
		/// <remarks/>
		[XmlArrayItem("otherArchive", IsNullable=false)]
		public string[] otherArchives {
			get {
				return this.otherArchivesField;
			}
			set {
				this.otherArchivesField = value;
			}
		}
	}
}