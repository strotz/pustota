using System.Collections.Generic;

namespace Pustota.Maven.Serialization
{
	public interface IProjectTreeLoader
	{
		IEnumerable<ProjectTreeElement> LoadProjectTree(string fileName);
		IEnumerable<ProjectTreeElement> ScanForProjects(string folderName);
		void SaveProjects(IEnumerable<ProjectTreeElement> projects);
	}
}