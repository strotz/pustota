namespace Pustota.Maven.Models
{
	public interface IProjectReference
	{
		string ArtifactId { get; set; }
		string GroupId { get; set; }
		ComponentVersion Version { get; set; }
	}
}