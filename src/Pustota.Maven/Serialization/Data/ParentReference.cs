using System.ComponentModel;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	internal class ParentReference : 
		ProjectReference,
		IParentReference
	{
		public string RelativePath { get; set; }
	}
}
