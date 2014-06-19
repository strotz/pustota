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

		internal const string DefaultNamespaceName = "pom";

		private static readonly XNamespace XmlNs;
		private static readonly XNamespace Xsi;
		private static readonly XNamespace SchemaLocation;
		private static readonly XmlNamespaceManager NsManager;

		static ProjectObjectModel()
		{
			XmlNs = XNamespace.Get(@"http://maven.apache.org/POM/4.0.0");
			Xsi = XNamespace.Get(@"http://www.w3.org/2001/XMLSchema-instance");
			SchemaLocation = XNamespace.Get(@"http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd");

			NsManager = new XmlNamespaceManager(new NameTable());
			NsManager.AddNamespace(NamespaceName, XmlNs.NamespaceName);
		}

		internal ProjectObjectModel() :
			this(BuildEmptyDocument())
		{
		}

		private static XDocument BuildEmptyDocument()
		{
			return new XDocument(
				new XDeclaration("1.0", "us-ascii", null),
				new XElement(XmlNs + "project",
					new XAttribute("xmlns", XmlNs),
					new XAttribute(XNamespace.Xmlns + "xsi", Xsi),
					new XAttribute(Xsi + "schemaLocation", SchemaLocation)
				)
			);
		}

		internal ProjectObjectModel(XDocument document)
		{
			_document = document;
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

		internal XElement SingleOrCreate(XElement startElement, string name)
		{
			XElement element = startElement.Elements(XmlNs + name).SingleOrDefault();
			if (element == null)
			{
				element = new XElement(XmlNs + name);
				startElement.Add(element);
			}
			return element;
		}

		internal XElement ReadElementOrNull(params string[] pathElems)
		{
			return ReadElements(RootElement, pathElems).SingleOrDefault();
		}

		internal XElement ReadElementOrNull(XElement startElement, params string[] pathElems)
		{
			return ReadElements(startElement, pathElems).SingleOrDefault();
		}

		internal string ReadElementValueOrNull(params string[] pathElems)
		{
			return ReadElementValueOrNull(RootElement, pathElems);
		}

		internal string ReadElementValueOrNull(XElement startElement, params string[] pathElems)
		{
			XElement element = ReadElementOrNull(startElement, pathElems);
			return element == null ? null : element.Value;
		}

		internal void SetElementValue(string name, string value)
		{
			SetElementValue(RootElement, name, value);
		}

		internal void SetElementValue(XElement startElement, string name, string value)
		{
			startElement.SetElementValue(XmlNs + name, value);
		}

		// REVIEW: redo, to remove ApplyNamespace
		internal IEnumerable<XElement> ReadElements(XElement startElement, params string[] pathElems)
		{
			string path = string.Join("/", pathElems.Select(ApplyNamespace).ToArray());
			return startElement.XPathSelectElements(path, NsManager);
		}

		internal void RemoveElement(string name)
		{
			RemoveElement(RootElement, name);
		}

		internal void RemoveElement(XElement startElement, string name)
		{
			var child = startElement.Element(XmlNs + name);
			if (child != null)
			{
				child.Remove();
			}
		}

		public override string ToString()
		{
			return _document.ToString();
		}
	}
}