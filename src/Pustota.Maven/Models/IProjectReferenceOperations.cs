namespace Pustota.Maven.Models
{
	public interface IProjectReferenceOperations
	{
		bool ReferenceEqualTo(IProjectReference another, bool strictVersion = true);

		bool IsEmpty { get; }

		// TODO: maybe move to version
		bool VersionEqualTo(string anotherVersion);
		bool IsSnapshot { get; }
		string SwitchToRelease(string postfix = null);
		string SwitchToSnapshotWithVersionIncrement();
	}
}