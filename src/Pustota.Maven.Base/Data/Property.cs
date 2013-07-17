using System.Xml;

namespace Pustota.Maven.Base.Data
{
	public class Property
	{
		public string Name { get; set; }
		public string Value { get; set; }

		public override string ToString()
		{
			return string.Format("Property:{0}={1}", Name, Value);
		}
	}
}
