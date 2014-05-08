using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Pustota.Maven.Editor.PomXml
{
	internal class XmlDocumentBase
	{
		private readonly XDocument _xmlDoc;
		private readonly PomXmlElement _root;

		private string _namespaceName;
		public XmlNamespaceManager NsManager;

		protected XmlDocumentBase(XDocument xdoc)
		{
			_xmlDoc = xdoc;
			_root = new PomXmlElement(this, xdoc.Root);
		}

		protected XmlDocumentBase(XDocument xdoc, string namespaceName)
			:this(xdoc)
		{
			SetNamespace(namespaceName);
		}

		// REVIEW: remove 
		internal string ApplyNamespace(string elementName)
		{
			if (string.IsNullOrEmpty(_namespaceName))
			{
				return elementName;
			}
			return _namespaceName + ":" + elementName;
		}

		private void SetNamespace(string namespaceName)
		{
			_namespaceName = namespaceName;

			NsManager = new XmlNamespaceManager(new NameTable());
			if (_xmlDoc.Root != null)
				NsManager.AddNamespace(namespaceName, _xmlDoc.Root.GetDefaultNamespace().NamespaceName);
		}

		public PomXmlElement Root 
		{
			get { return _root; }
		}

		public string ReadElementValue(params string[] pathElems)
		{
			return _root.ReadElementValue(pathElems);
		}

		public PomXmlElement ReadElement(params string[] pathElems)
		{
			return _root.ReadElement(pathElems);
		}

		public IEnumerable<PomXmlElement> ReadElements(params string[] pathElems)
		{
			return _root.ReadElements(pathElems);
		}

		public PomXmlElement ReadOrCreateElement(params string[] pathElems)
		{
			return _root.ReadOrCreateElement(pathElems);
		}

		public void SetElementValue(string name, string value)
		{
			_root.SetElementValue(name, value);
		}

		public override string ToString()
		{
			return _xmlDoc.ToString();
		}

		// TODO: refactor
		public void SaveTo(string fileName)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Encoding = Encoding.ASCII,
				Indent = true,
				IndentChars = "\t"
			};
			var directoryInfo = (new FileInfo(fileName)).Directory;
			if (directoryInfo != null) directoryInfo.Create();
			using (XmlWriter writer = XmlWriter.Create(fileName, settings))
			{
				_xmlDoc.WriteTo(writer);
			}
		}
	}
}