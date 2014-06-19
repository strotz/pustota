using System.ComponentModel;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	class Module : IModule
	{
		public string Path { get; set; }

		public override string ToString()
		{
			return Path;
		}
	}
}
