using System.Xml.Linq;
using System.Xml;

namespace Pustota.Maven.Editor.PomXml
{
	internal sealed class PomXmlDocument : 
		XmlDocumentBase
	{
		public const string DefaultNamespaceName = "pom";

		internal PomXmlDocument()
				: base(new XDocument(new XElement("project")))
		{
		}

		public PomXmlDocument(string fileName) :
			base(XDocument.Load(fileName), DefaultNamespaceName)
		{
		}

		private PomXmlDocument(XDocument xdoc, string namespaceName) :
			base(xdoc, namespaceName)
		{
		}

		public static bool TryParse(string text, out PomXmlDocument pomXmlDocument)
		{
			try
			{
				var xmlDoc = XDocument.Parse(text);
				pomXmlDocument = new PomXmlDocument(xmlDoc, DefaultNamespaceName);
				return true;
			}
			catch (XmlException)
			{
				pomXmlDocument = null;
				return false;
			}
		}
	}
}
