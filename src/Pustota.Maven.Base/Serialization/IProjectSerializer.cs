namespace Pustota.Maven.Base.Serialization
{
	public interface IProjectSerializer
	{
		Project Deserialize(string content);
		string Serialize(Project project);
	}
}