using System.ComponentModel;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	internal class Dependency : 
		ProjectReference,
		IDependency
	{
		internal Dependency()
		{
			Exclusions = new BlackBox();
		}

		public string Classifier { get; set; }
		public string Type { get; set; }
		public string Scope { get; set; }
		public bool Optional { get; set; }

		public IBlackBox Exclusions { get; set; }
	}
}
