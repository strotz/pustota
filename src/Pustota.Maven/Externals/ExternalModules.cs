using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pustota.Maven.Externals;

namespace Pustota.Maven.Editor.Externals
{
	class ExternalModules
	{
		private readonly ExternalModulesDocument _doc;
		private readonly string _path;
		private bool _storageIsExists;

		public List<ExternalModule> Items { get; private set; }
		public bool Changed { get; set; }

		public ExternalModules(string path)
		{
			_path = path;
			Items = new List<ExternalModule>();
			_storageIsExists = File.Exists(path);
			if (_storageIsExists)
			{
				try
				{
					_doc = new ExternalModulesDocument(_path);
				}
				catch (System.Xml.XmlException)
				{
					_doc = new ExternalModulesDocument();
				}
			}
			else
			{
				_doc = new ExternalModulesDocument();
			}
		}

		public void LoadModules()
		{
			if (_storageIsExists)
				Items = _doc.ReadElements(".", "module").Select(e =>
					{
						string artifactId = e.ReadElementValue("artifactId");
						string groupId = e.ReadElementValue("groupId");
						string version = e.ReadElementValue("version");
						return new ExternalModule(groupId, artifactId, version, _path);
					}).ToList();
		}

		public void Save()
		{
			AdjustXML();
			if (Items.Count != 0 || _storageIsExists)
			{
				_doc.SaveTo(_path);

			}
			Changed = false;
			_storageIsExists = File.Exists(_path);
		}

		private void AdjustXML()
		{
			var modulesNode = _doc.ReadOrCreateElement("/modules");
			if (Items.Count == 0)
			{
				modulesNode.RemoveAllChildElements();
			}
			else
			{
				modulesNode.RemoveAllChildElements();
				foreach (var module in Items)
				{
					var moduleNode = modulesNode.CreateElement("module");

					module.SaveTo(moduleNode);
				}
			}
		}
	}
}
