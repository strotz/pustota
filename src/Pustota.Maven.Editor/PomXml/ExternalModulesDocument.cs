using System.Xml.Linq;

namespace Pustota.Maven.Editor.PomXml
{
	internal class ExternalModulesDocument : XmlDocumentBase
	{
		internal ExternalModulesDocument() :
			base(new XDocument(new XElement("modules")))
		{
		}

		public ExternalModulesDocument(string path)
			: base(XDocument.Load(path))
		{
		}
	}
}