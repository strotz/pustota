using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Pustota.Maven.Base.Serialization
{
	public class ProjectXmlDocument
	{
		private readonly XDocument _xmlDoc;

		public XmlNamespaceManager NsManager;
		public const string DefaultNamespaceName = "pom";
		public string NamespaceName;

		private readonly XElement _root;

		private readonly bool _enableFormatting;

		public class UsAsciiStringWriter : StringWriter
		{
			public UsAsciiStringWriter()
				: base((IFormatProvider) null)
			{
			}

			public override Encoding Encoding { get { return Encoding.ASCII; } }
		}

		public ProjectXmlDocument()
		{
			XNamespace xmlns = XNamespace.Get(@"http://maven.apache.org/POM/4.0.0");
			XNamespace xsi = XNamespace.Get(@"http://www.w3.org/2001/XMLSchema-instance");
			XNamespace schemaLocation = XNamespace.Get(@"http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd");

			_xmlDoc = new XDocument(
				new XDeclaration("1.0", "us-ascii", null),
				new XElement(xmlns + "project",
					new XAttribute("xmlns", xmlns),
					new XAttribute(XNamespace.Xmlns + "xsi", xsi),
					new XAttribute(xsi + "schemaLocation", schemaLocation)
				)
			);

			_root = _xmlDoc.Root;

			_enableFormatting = true;
		}

		private ProjectXmlDocument(XDocument document)
		{
			_xmlDoc = document;
			_root = _xmlDoc.Root;
			_enableFormatting = false;
		}

		public XElement Root
		{
			get { return _root; }
		}

		public override string ToString()
		{
			using (TextWriter writer = new UsAsciiStringWriter())
			{
				_xmlDoc.Save(writer, _enableFormatting ? SaveOptions.None : SaveOptions.DisableFormatting);
				return writer.ToString();
			}
		}

		public static ProjectXmlDocument Load(string content)
		{
			var document = XDocument.Parse(content, LoadOptions.PreserveWhitespace);
			return new ProjectXmlDocument(document);
		}
	}
}
