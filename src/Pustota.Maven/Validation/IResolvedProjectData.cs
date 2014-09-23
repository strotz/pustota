namespace Pustota.Maven.Validation
{
	public interface IResolvedProjectData
	{
		string GroupId { get; }
		string Version { get; }
		bool? IsSnapshot { get; }
	}
}