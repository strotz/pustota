namespace Pustota.Maven.Editor.Models
{
	public interface IParentReference : IProjectReference
	{
		string RelativePath { get; set; }
		string ToString();
	}
}