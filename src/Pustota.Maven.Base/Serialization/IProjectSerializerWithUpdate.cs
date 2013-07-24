using Pustota.Maven.Base.Data;

namespace Pustota.Maven.Base.Serialization
{
	public interface IProjectSerializerWithUpdate : IProjectSerializer
	{
		string UpdateContent(Project project, string content);
	}
}