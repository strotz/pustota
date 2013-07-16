namespace Pustota.Maven.Base
{
	public interface IProjectReference
	{
		string ArtifactId { get; set; }
		string GroupId { get; set; }
		string Version { get; set; }
	}
}