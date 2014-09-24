using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization
{
	public interface IProjectTreeLoader
	{
		IEnumerable<IProjectTreeItem> LoadProjectTree(string fileName);
		IEnumerable<IProjectTreeItem> ScanForProjects(string folderName);
		void SaveProjects(IEnumerable<IProjectTreeItem> projects);
	}
}