using System.ComponentModel;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	class Profile : 
		BuildContainter,
		IProfile
	{
		public string Id { get; set; }
	}
}
