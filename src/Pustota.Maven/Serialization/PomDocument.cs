using System;
using System.Xml.Linq;

namespace Pustota.Maven.Serialization
{
	internal class PomDocument
	{
		private readonly XDocument _document;

		internal PomDocument() :
			this(BuildEmptyDocument())
		{
		}

		private static XDocument BuildEmptyDocument()
		{
			return new XDocument(
				new XDeclaration("1.0", "us-ascii", null),
				new XElement(MavenSerialization.XmlNs + "project",
					new XAttribute("xmlns", MavenSerialization.XmlNs),
					new XAttribute(XNamespace.Xmlns + "xsi", MavenSerialization.Xsi),
					new XAttribute(MavenSerialization.Xsi + "schemaLocation", MavenSerialization.SchemaLocation)
				)
			);
		}

		internal PomDocument(XDocument document)
		{
			_document = document;
		}

		internal PomElement RootElement
		{
			get { return new PomElement(_document.Root); }
		}

		public override string ToString()
		{
			return _document.ToString();
		}
	}
}