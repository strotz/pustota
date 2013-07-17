using System;
using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	[Serializable]
	[System.Diagnostics.DebuggerStepThroughAttribute]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://maven.apache.org/POM/4.0.0")]
	public class Dependency :
		ProjectReferenceBase
	{
		public Dependency()
		{
			Type = "jar";
			Optional = false;
		}

		[System.ComponentModel.DefaultValueAttribute("jar")]
		[XmlElement("type")]
		public string Type { get; set; }

		[XmlElement("classifier")]
		public string Classifier { get; set; }

		[XmlElement("scope")]
		public string Scope { get; set; }

		/// <remarks/>
		public string systemPath { get; set; }

		/// <remarks/>
		[XmlArrayItem("exclusion", IsNullable = false)]
		public Exclusion[] exclusions { get; set; }

		/// <remarks/>
		[System.ComponentModel.DefaultValueAttribute(false)]
		[XmlElement("optional")]
		public bool Optional { get; set; }
	}
}