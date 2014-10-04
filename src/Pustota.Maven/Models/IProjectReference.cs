namespace Pustota.Maven.Models
{
	public interface IProjectReference
	{
		string ArtifactId { get; set; }
		string GroupId { get; set; }
		Version Version { get; set; }
	}
}