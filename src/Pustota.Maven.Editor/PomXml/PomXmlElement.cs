using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Diagnostics;

namespace Pustota.Maven.Editor.PomXml
{
	class PomXmlElement
	{
		private readonly XmlDocumentBase _doc;
		private readonly XElement _elem;

		public PomXmlElement(XmlDocumentBase doc, XElement elem)
		{
			Debug.Assert(doc != null);
			Debug.Assert(elem != null);
			_doc = doc;
			_elem = elem;
		}

		public string LocalName
		{
			get { return _elem.Name.LocalName; }
		}

		public string Value
		{
			get { return _elem.Value; }
			set { _elem.Value = value; }
		}

		public void Remove()
		{
			_elem.Remove();
		}

		public IEnumerable<PomXmlElement> Elements
		{
			get
			{
				return _elem.Elements().Select(e => new PomXmlElement(_doc, e));
			}
		}

		public void RemoveAllChildElements()
		{
			_elem.Elements().Remove();
		}

		private XElement Element
		{
			get
			{
				return _elem;
			}
		}

		public XNamespace DefaultNamespace
		{
			get
			{
				return _elem.GetDefaultNamespace();
			}
		}

		public void SetElementValue(string name, string value)
		{
			_elem.SetElementValue(DefaultNamespace + name, value);
		}

		// REVIEW: redo, to remove ApplyNamespace
		public IEnumerable<PomXmlElement> ReadElements(params string[] pathElems)
		{
			string path = string.Join("/", pathElems.Select(name => _doc.ApplyNamespace(name)).ToArray());
			if (_doc.NsManager != null)
			{
				return _elem.XPathSelectElements(path, _doc.NsManager).Select(WrapElement);
			}
			return _elem.XPathSelectElements(path).Select(WrapElement);
		}

		public PomXmlElement ReadElement(params string[] pathElems)
		{
			return ReadElements(pathElems).FirstOrDefault();
		}

		public PomXmlElement ReadOrCreateElement(params string[] pathElems)
		{
			var result = ReadElement(pathElems);
			return result ?? CreateElement(pathElems);
		}

		public string ReadElementValue(params string[] pathElems)
		{
			var elem = ReadElement(pathElems);
			return elem == null ? null : elem.Value;
		}

		public PomXmlElement CreateElement(params string[] pathElems)
		{
			string name = pathElems.First();
			XElement newElem = new XElement(DefaultNamespace + name);
			_elem.Add(newElem);

			if (pathElems.Length == 1)
				return WrapElement(newElem);

			return WrapElement(newElem).CreateElement(pathElems.Skip(1).ToArray());
		}

		private PomXmlElement WrapElement(XElement elem)
		{
			return elem == null ? null : new PomXmlElement(_doc, elem);
		}

		public override bool Equals(object obj)
		{
			PomXmlElement other = obj as PomXmlElement;
			if (other == null)
				return false;
			return other.Element == Element;
		}

		public override int GetHashCode()
		{
			return _elem.GetHashCode();
		}

		public void AddElement(PomXmlElement element)
		{
			_elem.Add(element._elem);
		}
	}
}
