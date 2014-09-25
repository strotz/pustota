namespace Pustota.Maven.Models
{
	internal class ResolvedProjectData : IResolvedProjectData
	{
		public string GroupId { get; internal set; }

		// REVIEW: class for Version
		public string Version { get; internal set; }
		public bool? IsSnapshot { get; internal set; }

		public string RelativeParentPath { get; internal set; }
	}
}