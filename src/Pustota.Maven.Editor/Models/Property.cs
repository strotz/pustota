using System.ComponentModel;
using Pustota.Maven.Editor.PomXml;

namespace Pustota.Maven.Editor.Models
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	class Property : IProperty
	{
		public string Name { get; set; }
		public string Value { get; set; }

		public  Property() {}

		public Property(PomXmlElement e)
		{
			Name = e.LocalName;
			Value = e.Value;
		}

		public void SaveTo(PomXmlElement propertiesNode)
		{
			propertiesNode.SetElementValue(Name, Value);
		}

		public Property(string name, string value)
		{
			Name = name;
			Value = value;
		}

		public override string ToString()
		{
			return string.Format("Property:{0}={1}", Name, Value);
		}
	}
}
