using System.ComponentModel;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	internal class ProjectReference : IProjectReference
	{
		public string ArtifactId { get; set; }
		public string GroupId { get; set; }
		public string Version { get; set; }

		// REVIEW: review all usage
		public override string ToString()
		{
			return this.GetProjectKey();
		}
	}
}