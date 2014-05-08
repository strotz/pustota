using System.Xml.Linq;

namespace Pustota.Maven.Editor.PomXml
{
	internal class IgnoredValidationsDocument : XmlDocumentBase
	{
		internal IgnoredValidationsDocument()
			: base(new XDocument(new XElement("modules")))
		{
		}

		public IgnoredValidationsDocument(string path)
			: base(XDocument.Load(path))
		{
		}
	}
}