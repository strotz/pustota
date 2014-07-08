using System;
using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization
{
	public interface IProjectTreeLoader
	{
		// TODO: coordinate with RepositoryEntryPoint entryPoint
		IEnumerable<Tuple<string,IProject>> LoadProjectTree(string fileOrFolderName);
	}
}