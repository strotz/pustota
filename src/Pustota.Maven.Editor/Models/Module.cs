using System.ComponentModel;

namespace Pustota.Maven.Editor.Models
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	class Module : IModule
	{
		public string Path { get; set; }

		public Module()
		{

		}
		public Module(PomXml.PomXmlElement e)
		{
			Path = e.Value;
		}

		public void SaveTo(PomXml.PomXmlElement moduleNode)
		{
			moduleNode.Value = Path;
		}

		public override string ToString()
		{
			return Path;
		}
	}
}
