using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Pustota.Maven.Serialization
{
	internal class PomElement
	{
		internal class Comparer : IEqualityComparer<PomElement>
		{
			public bool Equals(PomElement x, PomElement y)
			{
				return Equals(x._element, y._element);
			}

			public int GetHashCode(PomElement obj)
			{
				return obj._element.GetHashCode();
			}
		}

		private readonly XElement _element;

		internal PomElement(XElement element)
		{
			_element = element;
		}

		private static PomElement Wrap(XElement element)
		{
			return new PomElement(element);
		}

		private static XName Name(string name)
		{
			return MavenSerialization.XmlNs + name;
		}

		internal string LocalName
		{
			get { return _element.Name.LocalName; }
		}

		internal string Value
		{
			get { return _element.Value; }
			set { _element.Value = value; }
		}

		internal PomElement AddElement(string name)
		{
			var element = new XElement(Name(name));
			_element.Add(element);
			return Wrap(element);
		}

		internal void Add(PomElement childElement)
		{
			_element.Add(childElement._element);
		}

		internal void ReplaceWith(PomElement element)
		{
			_element.ReplaceWith(element._element);
		}

		internal void SetElementValue(string name, string value)
		{
			_element.SetElementValue(Name(name), value);
		}

		internal PomElement SingleOrCreate(string name)
		{
			// TODO: review usage, what will happend if 2
			var result = _element.Elements(Name(name)).Select(Wrap).ToArray();
			int count = result.Length;
			if (count == 0)
			{
				return AddElement(name);
			}
			if (count == 1)
			{
				return result.Single();
			}
			string message = string.Format("Found 2 elements with same name {0}", name);
			throw new InvalidOperationException(message);
		}

		// REVIEW: remove 
		private static string ApplyNamespace(string elementName)
		{
			return MavenSerialization.NamespaceName + ":" + elementName;
		}

		// REVIEW: redo, to remove ApplyNamespace
		internal IEnumerable<PomElement> ReadElements(params string[] pathElems)
		{
			string path = string.Join("/", pathElems.Select(ApplyNamespace).ToArray());
			return _element.XPathSelectElements(path, MavenSerialization.NsManager).Select(Wrap);
		}

		internal string ReadElementValueOrNull(params string[] pathElems)
		{
			PomElement element = SingleOrNull(pathElems);
			return element == null ? null : element.Value;
		}

		internal IEnumerable<PomElement> Elements()
		{
			return _element.Elements().Select(Wrap);
		}

		internal void RemoveAllChildElements()
		{
			_element.Value = string.Empty;
			_element.Elements().Remove();
		}

		internal PomElement SingleOrNull(params string[] pathElems)
		{
			var result = ReadElements(pathElems).ToArray();
			int count = result.Length;
			if (count == 0)
			{
				return null;
			}
			if (count == 1)
			{
				return result.Single();
			}
			string message = string.Format("Found 2 elements with same path {0}", string.Join("/", pathElems));
			throw new InvalidOperationException(message);
		}

		internal void RemoveElement(string name)
		{
			var child = _element.Element(Name(name));
			if (child != null)
			{
				child.Remove();
			}
		}

		public void Remove()
		{
			_element.Remove();
		}
	}
}