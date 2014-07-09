using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization
{
	public interface IProjectSerializerWithUpdate : IProjectSerializer
	{
		string Serialize(IProject project, string contentToUpdate);
	}
}