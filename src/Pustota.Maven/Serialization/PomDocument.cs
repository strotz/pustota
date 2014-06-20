using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Pustota.Maven.Serialization
{
	internal class MavenSerialization
	{
		internal const string DefaultNamespaceName = "pom";
		private const string NamespaceName = DefaultNamespaceName;

		internal static readonly XNamespace XmlNs;
		internal static readonly XNamespace Xsi;
		internal static readonly XNamespace SchemaLocation;
		internal static readonly XmlNamespaceManager NsManager;

		static MavenSerialization()
		{
			XmlNs = XNamespace.Get(@"http://maven.apache.org/POM/4.0.0");
			Xsi = XNamespace.Get(@"http://www.w3.org/2001/XMLSchema-instance");
			SchemaLocation = XNamespace.Get(@"http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd");

			NsManager = new XmlNamespaceManager(new NameTable());
			NsManager.AddNamespace(NamespaceName, XmlNs.NamespaceName);
		}
	}

	internal class PomElement
	{
		private readonly XElement _startElement;

		internal PomElement(XElement startElement)
		{
			_startElement = startElement;
		}

		private static PomElement Wrap(XElement element)
		{
			return new PomElement(element);
		}

		private static XName Name(string name)
		{
			return MavenSerialization.XmlNs + name;
		}

		public XElement AddElement(string name)
		{
			var element = new XElement(Name(name));
			_startElement.Add(element);
			return element;
		}

		internal void SetElementValue(string name, string value)
		{
			_startElement.SetElementValue(Name(name), value);
		}

		internal XElement SingleOrCreate(string name)
		{
			XElement element = _startElement.Elements(Name(name)).SingleOrDefault();
			if (element == null)
			{
				element = AddElement(name);
			}
			return element;
		}

		// REVIEW: remove 
		private static string ApplyNamespace(string elementName)
		{
			return NamespaceName + ":" + elementName;
		}

		// REVIEW: redo, to remove ApplyNamespace
		internal IEnumerable<XElement> ReadElements(params string[] pathElems)
		{
			string path = string.Join("/", pathElems.Select(ApplyNamespace).ToArray());
			return _startElement.XPathSelectElements(path, NsManager);
		}

		internal string ReadElementValueOrNull(params string[] pathElems)
		{
			XElement element = SingleOrNull(pathElems);
			return element == null ? null : element.Value;
		}

		internal void RemoveAllChildElements()
		{
			_startElement.Elements().Remove();
		}

		internal XElement SingleOrNull(params string[] pathElems)
		{
			return ReadElements(pathElems).SingleOrDefault();
		}

		internal void RemoveElement(string name)
		{
			var child = _startElement.Element(Name(name));
			if (child != null)
			{
				child.Remove();
			}
		}
	}

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

/*
		internal XElement SingleOrNull(params string[] pathElems)
		{
			return RootElement.ReadElements(pathElems).SingleOrDefault();
		}

		internal string ReadElementValueOrNull(params string[] pathElems)
		{
			return RootElement.ReadElementValueOrNull(pathElems);
		}

		internal void SetElementValue(string name, string value)
		{
			RootElement.SetElementValue(name, value);
		}

		internal void RemoveElement(string name)
		{
			RootElement.RemoveElement(name);
		}
*/
		public override string ToString()
		{
			return _document.ToString();
		}
	}
}