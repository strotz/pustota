namespace Pustota.Maven.Models
{
	public interface IProjectTreeItem
	{
		FullPath Path { get; }
		IProject Project { get; }
	}
}