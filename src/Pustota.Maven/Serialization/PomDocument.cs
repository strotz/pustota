using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
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
			return ToMavenXml(_document);
		}

		private string ToMavenXml(XDocument document)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Encoding = new UTF8Encoding(false),
				Indent = true,
				IndentChars = "\t"
			};
			using (var output = new MemoryStream())
			{
				using (var xmlWriter = XmlWriter.Create(output, settings))
				{
					document.WriteTo(xmlWriter);
				}
				string result = Encoding.Default.GetString(output.ToArray());
				return result;
			}
		}
	}
}