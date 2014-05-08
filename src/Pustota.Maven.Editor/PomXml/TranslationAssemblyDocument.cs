using System.Xml.Linq;

namespace Pustota.Maven.Editor.PomXml
{
	// TODO: vender customization
	internal class TranslationAssemblyDocument : XmlDocumentBase
	{
		internal TranslationAssemblyDocument() :
			base(CreateTranslationAssemblyDocument())
		{
		}

		private static XDocument CreateTranslationAssemblyDocument()
		{
			XNamespace ns = @"http://maven.apache.org/plugins/maven-assembly-plugin/assembly/1.1.2";
			return new XDocument(
				new XElement(ns + "assembly",
					new XAttribute("xmlns", ns),
					new XAttribute(XNamespace.Xmlns + "xsi", @"http://www.w3.org/2001/XMLSchema-instance"),
					new XAttribute(XNamespace.Xmlns + "schemaLocation", @"http://maven.apache.org/plugins/maven-assembly-plugin/assembly/1.1.2 http://maven.apache.org/xsd/assembly-1.1.2.xsd")
					)
				);
		}
	}
}