using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization
{
	public interface IProjectTreeLoader
	{
		// TODO: coordinate with RepositoryEntryPoint entryPoint
		IEnumerable<IProject> LoadProjectTree(string fileOrFolderName);
	}
}