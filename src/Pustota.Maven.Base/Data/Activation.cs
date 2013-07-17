using System;
using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	[Serializable]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://maven.apache.org/POM/4.0.0")]
	public class Activation
	{
		public Activation()
		{
			activeByDefault = false;
		}

		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool activeByDefault { get; set; }

		/// <remarks/>
		public string jdk { get; set; }

		/// <remarks/>
		public ActivationOS os { get; set; }

		/// <remarks/>
		public ActivationProperty property { get; set; }

		/// <remarks/>
		public ActivationFile file { get; set; }
	}
}