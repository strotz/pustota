using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	// [TypeConverter(typeof(ExpandableObjectConverter))]
	public class Module
	{
		[XmlText]
		public string Path { get; set; }

		public override string ToString()
		{
			return Path;
		}
	}
}
