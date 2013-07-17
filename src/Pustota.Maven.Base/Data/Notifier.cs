using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace="http://maven.apache.org/POM/4.0.0")]
	public partial class Notifier {
        
		private string typeField;
        
		private bool sendOnErrorField;
        
		private bool sendOnFailureField;
        
		private bool sendOnSuccessField;
        
		private bool sendOnWarningField;
        
		private string addressField;
        
		private NotifierConfiguration configurationField;
        
		public Notifier() {
			this.typeField = "mail";
			this.sendOnErrorField = true;
			this.sendOnFailureField = true;
			this.sendOnSuccessField = true;
			this.sendOnWarningField = true;
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute("mail")]
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool sendOnError {
			get {
				return this.sendOnErrorField;
			}
			set {
				this.sendOnErrorField = value;
			}
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool sendOnFailure {
			get {
				return this.sendOnFailureField;
			}
			set {
				this.sendOnFailureField = value;
			}
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool sendOnSuccess {
			get {
				return this.sendOnSuccessField;
			}
			set {
				this.sendOnSuccessField = value;
			}
		}
        
		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool sendOnWarning {
			get {
				return this.sendOnWarningField;
			}
			set {
				this.sendOnWarningField = value;
			}
		}
        
		/// <remarks/>
		public string address {
			get {
				return this.addressField;
			}
			set {
				this.addressField = value;
			}
		}
        
		/// <remarks/>
		public NotifierConfiguration configuration {
			get {
				return this.configurationField;
			}
			set {
				this.configurationField = value;
			}
		}
	}
}