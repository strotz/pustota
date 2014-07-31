using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Pustota.Maven.Editor.Validations;

namespace Pustota.Maven.Editor.Models
{
	//internal class ExtendedProject : IFixable

	//{
	//	private PomXmlDocument _pom;
	//	public string FullPath { get; set; } // REVIEW: remove to ProjectNode
	//	public bool Changed { get; set; }

	//	public string Title
	//	{
	//		get { return base.ToString(); }
	//	}

	//	public string Text
	//	{
	//		get { return _pom.ToString(); }
	//		set
	//		{
	//			PomXmlDocument pomXmlDocument;
	//			if (!PomXmlDocument.TryParse(value, out pomXmlDocument))
	//			{
	//				throw new ArgumentException("XML Parsing Error: not well-formed");
	//			}

	//			_pom = pomXmlDocument;

	//			LoadDataFromXml(_pom);

	//			Changed = true;
	//		}
	//	}

	//	public PomXmlDocument GetPomXml()
	//	{
	//		UpdateXmlFromData(_pom);
	//		return _pom;
	//	}

	//	public void UpdatePomXml(PomXmlDocument pom) // crUd
	//	{
	//		_pom = pom;
	//		UpdateXmlFromData(_pom);
	//	}

	//	internal void LoadDataFromXml(PomXmlDocument pom)
	//	{
	//		if (pom == null)
	//			throw new ArgumentNullException("pom");

	//		_pom = pom;

	//		var root = pom.Root;

	//		LoadFromElement(root);

	//		Changed = false;
	//	}
	//}
}