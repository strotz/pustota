namespace Pustota.Maven.Models
{
	public interface IProjectTreeItem
	{
		string Path { get; }
		IProject Project { get; }
	}
}