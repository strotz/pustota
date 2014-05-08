using System.ComponentModel;
using Pustota.Maven.Editor.PomXml;

namespace Pustota.Maven.Editor.Models
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	internal class Dependency : 
		ProjectReference,
		IDependency
	{
		public string Classifier { get; set; }
		public string Type { get; set; }
		public string Scope { get; set; }
		public bool Optional { get; set; }

		internal protected override void LoadFromElement(PomXmlElement element)
		{
			base.LoadFromElement(element);

			Scope = element.ReadElementValue("scope");
			Type = element.ReadElementValue("type");
			Classifier = element.ReadElementValue("classifier");

			bool optional;
			Optional = bool.TryParse(element.ReadElementValue("optional"), out optional) && optional;
		}

		internal protected override void SaveToElement(PomXmlElement element)
		{
			base.SaveToElement(element);

			element.SetElementValue("type", Type);
			element.SetElementValue("classifier", Classifier);
			element.SetElementValue("scope", Scope);

			if (Optional)
				element.SetElementValue("optional", "true");
		}
	}
}
