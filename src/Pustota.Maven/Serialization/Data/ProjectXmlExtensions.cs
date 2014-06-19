using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Pustota.Maven.Serialization.Data
{
	// TODO: review
	internal static class ProjectXmlExtensions
	{

		public static PomXmlElement ReadElement(this PomXmlElement root, params string[] pathElems)
		{
			return root.ReadElement(pathElems);
		}

		public static IEnumerable<PomXmlElement> ReadElements(this PomXmlElement root, params string[] pathElems)
		{
			return root.ReadElements(pathElems);
		}

		public static PomXmlElement ReadOrCreateElement(this PomXmlElement root, params string[] pathElems)
		{
			return root.ReadOrCreateElement(pathElems);
		}

		public static void SetElementValue(this PomXmlElement root, string name, string value)
		{
			root.SetElementValue(name, value);
		}
	}
}