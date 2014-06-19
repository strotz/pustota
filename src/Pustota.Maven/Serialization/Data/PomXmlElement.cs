using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Pustota.Maven.Serialization.Data
{
	// REVIEW: need refactoring: XElement is powerful, need a couple of extensions 
	public class PomXmlElement
	{
		//private readonly XmlDocumentBase _doc;
		private readonly XElement _elem;

		//internal PomXmlElement(XmlDocumentBase doc, XElement elem)
		//{
		//	_doc = doc;
		//	_elem = elem;
		//}

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
				throw new NotImplementedException();
				// return _elem.Elements().Select(e => new PomXmlElement(_doc, e));
			}
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
