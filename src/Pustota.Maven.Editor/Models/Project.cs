using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Editor.PomXml;
using Pustota.Maven.Editor.Validations;

namespace Pustota.Maven.Editor.Models
{
	internal class Project : 
		ProjectReference,
		IProject, 
		IFixable
	{
		private PomXmlDocument _pom;

		public string FullPath { get; set; } // REVIEW: remove to ProjectNode
		
		public bool Changed { get; set; }

		public string Name { get; set; }
		public string Packaging { get; set; }
		public string ModelVersion { get; set; }

		public IParentReference Parent { get; set; }

		public List<IProfile> Profiles { get; set; }

		public IEnumerable<IDependency> AllDependencies
		{
			get
			{
				return Dependencies.Concat(Profiles.SelectMany(p => p.Dependencies));
			}
		}
		
		public IEnumerable<IProperty> AllProperties
		{
			get
			{
				return Properties.Concat(Profiles.SelectMany(p => p.Properties));
			}
		}
		
		public IEnumerable<IModule> AllModules
		{
			get
			{
				return Modules.Concat(Profiles.SelectMany(p => p.Modules));
			}
		}

		public IEnumerable<IPlugin> AllPlugins
		{
			get
			{
				return Plugins
					.Concat(PluginManagement)
					.Concat(Profiles.SelectMany(p => p.Plugins))
					.Concat(Profiles.SelectMany(p => p.PluginManagement));
			}
		}


		private readonly BuildContainter _container;

		private readonly DataFactory _dataFactory;

		public Project()
		{
			_dataFactory = new DataFactory(); // TODO: DI
			_container = new BuildContainter();
			Profiles = new List<IProfile>();
		}

		public string Title
		{
			get { return base.ToString(); }
		}


		// expose build container via adapter
		public List<IModule> Modules
		{
			get { return _container.Modules; }
			set { _container.Modules = value; }
		}

		public List<IDependency> Dependencies
		{
			get { return _container.Dependencies; }
			set { _container.Dependencies = value; }
		}

		public List<IProperty> Properties
		{
			get { return _container.Properties; }
			set { _container.Properties = value; }
		}

		public List<IPlugin> Plugins
		{
			get { return _container.Plugins; }
			set { _container.Plugins = value; }
		}

		public List<IPlugin> PluginManagement
		{
			get { return _container.PluginManagement; }
			set { _container.PluginManagement = value; }
		}

		public string Text
		{
			get
			{
				return _pom.ToString();
			}
			set
			{
				PomXmlDocument pomXmlDocument;
				if (!PomXmlDocument.TryParse(value, out pomXmlDocument))
				{
					throw new ArgumentException("XML Parsing Error: not well-formed");
				}
				
				_pom = pomXmlDocument;

				LoadDataFromXml(_pom);

				Changed = true;
			}
		}

		public PomXmlDocument GetPomXml()
		{
			UpdateXmlFromData(_pom);
			return _pom;
		}

		public void UpdatePomXml(PomXmlDocument pom)  // crUd
		{
			_pom = pom;
			UpdateXmlFromData(_pom);
		}

		private void UpdateXmlFromData(PomXmlDocument pom)
		{
			var root = pom.Root;

			base.SaveToElement(root);

			pom.SetElementValue("packaging", Packaging);
			pom.SetElementValue("name", Name);
			pom.SetElementValue("modelVersion", ModelVersion);

			//writing parent
			var parentNode = pom.ReadOrCreateElement("parent");
			if (Parent == null)
			{
				parentNode.Remove();
			}
			else
			{
				((ParentReference)Parent).SaveToElement(parentNode);
			}

			_container.SaveToElement(root);

			//writing profiles
			var profileNode = pom.ReadOrCreateElement("profiles");
			if (!Profiles.Any())
			{
				profileNode.Remove();
			}
			else
			{
				HashSet<PomXmlElement> usedElements = new HashSet<PomXmlElement>();
				foreach (Profile prof in Profiles)
				{
					var profElement = profileNode.Elements.FirstOrDefault(e => e.ReadElementValue("id") == prof.Id) ??
						profileNode.CreateElement("profile");

					usedElements.Add(profElement);
					prof.SaveToElement(profElement);
				}

				//delete all profiles elements which are not in the Profiles array
				foreach (var profElem in profileNode.Elements.Where(e => !usedElements.Contains(e)))
					profElem.Remove();
			}
		}

		internal void LoadDataFromXml(PomXmlDocument pom)
		{
			if (pom == null)
				throw new ArgumentNullException("pom");

			_pom = pom;

			var root = pom.Root;

			LoadFromElement(root);

			Changed = false;
		}

		protected internal override void LoadFromElement(PomXmlElement element)
		{
			base.LoadFromElement(element);

			Packaging = element.ReadElementValue("packaging");
			Name = element.ReadElementValue("name");
			ModelVersion = element.ReadElementValue("modelVersion");

			//read parent
			var parentNode = element.ReadElement("parent");
			Parent = parentNode == null ? null : _dataFactory.CreateParentReference(parentNode);

			_container.LoadFromElement(element);

			//load profiles
			Profiles = element.ReadElements("profiles", "profile")
					.Select(e => _dataFactory.CreateProfile(e)).ToList();
		}
	}
}
