using System.Xml.Linq;

namespace Pustota.Maven.Externals
{
	internal class ExternalModulesDocument
	{
		private XDocument _document;

		internal ExternalModulesDocument()
		{
			_document = new XDocument(
				new XElement("modules"));
		}

		public ExternalModulesDocument(string path)
		{
			_document = XDocument.Load(path);
		}
	}
}