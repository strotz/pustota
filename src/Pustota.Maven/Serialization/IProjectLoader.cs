using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization
{
	public interface IProjectReader
	{
		IProject ReadProject(string path);
	}

	internal interface IProjectLoader :
		IProjectReader
		// TODO: IProjectWriter
	{
		//void WriteProject(IProject project, string path);
		//void UpdateProject(IProject project, string path);
	}
}