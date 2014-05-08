using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Pustota.Maven.Editor.PomXml;

namespace Pustota.Maven.Editor.Models
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	class Profile : 
		BuildContainter,
		IProfile
	{
		public string Id { get; set; }

		internal protected override void LoadFromElement(PomXmlElement element)
		{
			Id = element.ReadElementValue("id");
			base.LoadFromElement(element);
		}

		protected internal override void SaveToElement(PomXmlElement profileElem)
		{
			var idElem = profileElem.ReadOrCreateElement("id");
			if (string.IsNullOrEmpty(Id))
				idElem.Remove();
			else
				idElem.Value = Id;

			base.SaveToElement(profileElem);
		}
	}
}
