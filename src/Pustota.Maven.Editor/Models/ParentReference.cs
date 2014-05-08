using System.ComponentModel;
using Pustota.Maven.Editor.PomXml;

namespace Pustota.Maven.Editor.Models
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	internal class ParentReference : 
		ProjectReference,
		IParentReference
	{
		public string RelativePath { get; set; }

		internal protected override void LoadFromElement(PomXmlElement element)
		{
			base.LoadFromElement(element);
			RelativePath = element.ReadElementValue("relativePath");
		}

		protected internal override void SaveToElement(PomXmlElement parentNode)
		{
			base.SaveToElement(parentNode);
			parentNode.SetElementValue("relativePath", RelativePath);
		}
	}
}
