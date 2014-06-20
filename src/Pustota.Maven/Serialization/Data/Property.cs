using System.ComponentModel;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	internal class Property : IProperty
	{
		public string Name { get; set; }
		public string Value { get; set; }

		internal Property()
		{
		}

		internal Property(string name, string value)
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
