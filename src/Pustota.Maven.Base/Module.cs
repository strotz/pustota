using System.ComponentModel;
using System.Xml.Serialization;

namespace Pustota.Maven.Base
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class Module : IModule
	{
		[XmlText]
		public string Path { get; set; }

		public override string ToString()
		{
			return Path;
		}
	}
}
