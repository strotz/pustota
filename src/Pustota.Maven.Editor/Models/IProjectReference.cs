namespace Pustota.Maven.Editor.Models
{
	public interface IProjectReference
	{
		string ArtifactId { get; set; }
		string GroupId { get; set; }
		string Version { get; set; }

		bool HasSpecificVersion { get; }

		string ProjectKey { get; }
	}
}