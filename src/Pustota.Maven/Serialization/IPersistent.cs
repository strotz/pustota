namespace Pustota.Maven.Serialization
{
	public interface IPersistent
	{
		string FullPath { get; }
		bool Changed { get; set; }
	}
}