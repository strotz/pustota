namespace Pustota.Maven.Models
{
	public interface IProjectReferenceOperations
	{
		bool ReferenceEqualTo(IProjectReference another, bool strictVersion = true);
		bool IsEmpty { get; }
	}
}