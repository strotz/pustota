using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
namespace Pustota.Maven.Base
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class Profile : IProfile
	{
		public Profile()
		{
			Modules = new List<Module>();
			Dependencies = new List<Dependency>();
			Properties = new List<Property>();
		}

		[XmlElement("id")]
		public string Id { get; set; }

		[XmlAnyElement("activation")]
		public XmlElement Activation { get; set; }

		[XmlArray("modules")]
		[XmlArrayItem("module")]
		public List<Module> Modules { get; set; }

		[XmlArray("dependencies")]
		[XmlArrayItem("dependency")]
		public List<Dependency> Dependencies { get; set; }

		[XmlElement("properties")]
		public List<Property> Properties { get; set; }
	}
}
