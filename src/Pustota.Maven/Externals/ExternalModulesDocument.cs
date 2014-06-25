using System.Xml.Linq;

namespace Pustota.Maven.Externals
{
//	internal class ExternalModulesDocument
//	{
//		private XDocument _document;

//		internal ExternalModulesDocument()
//		{
//			_document = new XDocument(
//				new XElement("modules"));
//		}

//		public ExternalModulesDocument()
//		{
//			_document = XDocument.Load(path);
//		}

////		private readonly string _path;


//	}

//	internal class ExternalModulesSerialization
//	{
//		internal ExternalModules Deserialize(string content)
//		{
//			var document = XDocument.Parse(content, LoadOptions.PreserveWhitespace);
//			var pom = new ExternalModulesDocument(document);
//			var modules = _dataFactory.CreateExternalModules();
//			LoadExternalModules(pom, project);
//			return project;
//		}

//		internal string Serialize(ExternalModules project)
//		{
			
//		}

//		public void LoadModules()
//		{
//			if (_storageIsExists)
//			{
//				try
//				{
//					_doc = new ExternalModulesDocument(_path);
//				}
//				catch (XmlException)
//				{
//					_doc = new ExternalModulesDocument();
//				}
//			}
//			else
//			{
//				_doc = new ExternalModulesDocument();
//			}

//			if (_storageIsExists)
//				Items = _doc.ReadElements(".", "module").Select(e =>
//				{
//					string artifactId = e.ReadElementValue("artifactId");
//					string groupId = e.ReadElementValue("groupId");
//					string version = e.ReadElementValue("version");
//					return new ExternalModule(groupId, artifactId, version, _path);
//				}).ToList();
//		}

//		public void Save()
//		{
//			AdjustXML();
//			if (Items.Count != 0 || _storageIsExists)
//			{
//				_doc.SaveTo(_path);

//			}
//			Changed = false;
//			_storageIsExists = File.Exists(_path);
//		}

//		private void AdjustXML()
//		{
//			var modulesNode = _doc.ReadOrCreateElement("/modules");
//			if (Items.Count == 0)
//			{
//				modulesNode.RemoveAllChildElements();
//			}
//			else
//			{
//				modulesNode.RemoveAllChildElements();
//				foreach (var module in Items)
//				{
//					var moduleNode = modulesNode.CreateElement("module");

//					module.SaveTo(moduleNode);
//				}
//			}
//		}

//	}
}