using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization
{
	public interface IProjectWriter
	{
		//void WriteProject(IProject project, string path);
		void UpdateProject(IProject project, string path);
	}
}