namespace Pustota.Maven.Models
{
	public static class ProjectReferenceExtensions
	{
		public static bool HasSpecificVersion(this IProjectReference reference)
		{
			return !string.IsNullOrEmpty(reference.Version);
		}

		public static string GetProjectKey(this IProjectReference reference)
		{
			return string.Format("{0}:{1} ({2})", reference.GroupId, reference.ArtifactId, reference.Version);
		} 
	}
}