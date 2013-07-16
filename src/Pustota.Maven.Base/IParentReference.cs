namespace Pustota.Maven.Base
{
	public interface IParentReference : IProjectReference
	{
		string RelativePath { get; set; }
	}
}