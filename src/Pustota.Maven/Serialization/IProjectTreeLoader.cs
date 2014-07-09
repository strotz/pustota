using System.Collections.Generic;

namespace Pustota.Maven.Serialization
{
	public interface IProjectTreeLoader
	{
		// TODO: coordinate with RepositoryEntryPoint entryPoint
		IEnumerable<ProjectTreeElement> LoadProjectTree(string fileOrFolderName);
		void SaveProjects(IEnumerable<ProjectTreeElement> projects);
	}
}