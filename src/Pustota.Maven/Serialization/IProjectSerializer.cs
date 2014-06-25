using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization
{
	public interface IProjectSerializer
	{
		IProject Deserialize(string content);
		string Serialize(IProject project);
	}
}