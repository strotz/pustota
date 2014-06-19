using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization
{
	internal interface IProjectLoader
	{
		IProject LoadProject(string path); // REVIEW: IProject?
		void SaveProject(IProject project, string path); // REVIEW: IProject?
	}
}