using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Pustota.Maven.Editor.Validations;

namespace Pustota.Maven.Editor.Models
{
	internal class ExtendedProject : IFixable

	{
		private PomXmlDocument _pom;
		public string FullPath { get; set; } // REVIEW: remove to ProjectNode
		public bool Changed { get; set; }

		private readonly DataFactory _dataFactory = new DataFactory(); // TODO: DI

		public string Title
		{
			get { return base.ToString(); }
		}


		public string Text
		{
			get { return _pom.ToString(); }
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

		public static bool TryParse(string text, out PomXmlDocument pomXmlDocument)
		{
			try
			{
				var xmlDoc = XDocument.Parse(text);
				pomXmlDocument = new PomXmlDocument(xmlDoc, DefaultNamespaceName);
				return true;
			}
			catch (XmlException)
			{
				pomXmlDocument = null;
				return false;
			}
		}


		public PomXmlDocument GetPomXml()
		{
			UpdateXmlFromData(_pom);
			return _pom;
		}

		public void UpdatePomXml(PomXmlDocument pom) // crUd
		{
			_pom = pom;
			UpdateXmlFromData(_pom);
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