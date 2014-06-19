using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Pustota.Maven.Serialization
{
	internal class ProjectObjectModel
	{
		private readonly XDocument _document;

		private const string NamespaceName = DefaultNamespaceName;
		private readonly XmlNamespaceManager _nsManager;
		internal const string DefaultNamespaceName = "pom";

		internal ProjectObjectModel()
		{
			XNamespace xmlns = XNamespace.Get(@"http://maven.apache.org/POM/4.0.0");
			XNamespace xsi = XNamespace.Get(@"http://www.w3.org/2001/XMLSchema-instance");
			XNamespace schemaLocation = XNamespace.Get(@"http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd");

			_document = new XDocument(
				new XDeclaration("1.0", "us-ascii", null),
				new XElement(xmlns + "project",
					new XAttribute("xmlns", xmlns),
					new XAttribute(XNamespace.Xmlns + "xsi", xsi),
					new XAttribute(xsi + "schemaLocation", schemaLocation)
				)
			);
		}

		internal ProjectObjectModel(XDocument document)
		{
			_document = document;

			_nsManager = new XmlNamespaceManager(new NameTable());
			_nsManager.AddNamespace(NamespaceName, _document.Root.GetDefaultNamespace().NamespaceName);
		}

		internal XElement RootElement
		{
			get { return _document.Root; }
		}

		// REVIEW: remove 
		private static string ApplyNamespace(string elementName)
		{
			return NamespaceName + ":" + elementName;
		}

		public string ReadElementValueOrNull( params string[] pathElems)
		{
			var element = ReadElements(_document.Root, pathElems).FirstOrDefault();
			return element == null ? null : element.Value;
		}

		// REVIEW: redo, to remove ApplyNamespace
		private IEnumerable<XElement> ReadElements(XElement startElement, params string[] pathElems)
		{
			string path = string.Join("/", pathElems.Select(ApplyNamespace).ToArray());
			return startElement.XPathSelectElements(path, _nsManager);
		}

		public override string ToString()
		{
			return _document.ToString();
		}
	}
}