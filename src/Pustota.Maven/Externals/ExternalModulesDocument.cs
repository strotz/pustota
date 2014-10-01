using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Pustota.Maven.Externals
{
	internal class ExternalModulesDocument
	{
		private readonly XDocument _document;

		internal ExternalModulesDocument() : this(BuildEmptyDocument())
		{
		}

		internal ExternalModulesDocument(XDocument document)
		{
			_document = document;
		}

		private static XDocument BuildEmptyDocument()
		{
			return new XDocument(
				new XDeclaration("1.0", "us-utf8", null),
				new XElement("modules")
				);
		}

		internal IEnumerable<IExternalModule> ReadModules()
		{
			return _document.Descendants("modules").Descendants("module").Select(ReadModuleElement);
		}

		private static IExternalModule ReadModuleElement(XElement element)
		{
			var result = new ExternalModule
			{
				GroupId = FirstValueOrNull(element, "groupId"),
				ArtifactId = FirstValueOrNull(element, "artifactId"),
				Version = FirstValueOrNull(element, "version")
			};
			return result;
		}

		private static string FirstValueOrNull(XElement element, string name)
		{
			var first = element.Element(name);
			if (first != null)
				return first.Value;
			return null;
		}
	}

	//public void SaveTo(PomXmlElement externalModuleNode)
	//{
	//	externalModuleNode.SetElementValue("artifactId", ArtifactId);
	//	externalModuleNode.SetElementValue("groupId", GroupId);
	//	externalModuleNode.SetElementValue("version", Version);
	//}


//	internal class ExternalModulesSerialization
//	{
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