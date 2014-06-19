namespace Pustota.Maven.Models
{
	public interface IParentReference : IProjectReference
	{
		string RelativePath { get; set; }
		string ToString();
	}
}