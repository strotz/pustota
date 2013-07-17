using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://maven.apache.org/POM/4.0.0")]
	public class Parent : ProjectReferenceBase
	{
		public Parent()
		{
			RelativePath = "../pom.xml";
		}

		[System.ComponentModel.DefaultValueAttribute("../pom.xml"), XmlElement("relativePath")]
		public string RelativePath { get; set; }
	}
}