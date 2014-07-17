using Pustota.Maven.Serialization;
using Pustota.Maven.Serialization.Data;
using Pustota.Maven.System;

namespace Pustota.Maven
{
	public class SolutionManagement
	{
		public ISolution OpenSolution(string fileOrFolderName, bool loadDisconnectedProjects)
		{
			FileSystemAccess fileIo = new FileSystemAccess();
			IDataFactory factory = new DataFactory();
			IProjectSerializerWithUpdate serializer = new ProjectSerializer(factory);
			IProjectLoader projectLoader = new ProjectLoader(fileIo, serializer);
			var loader = new ProjectTreeLoader(fileIo, projectLoader, projectLoader);

			var solution = new Solution(fileIo, loader);
			solution.Open(fileOrFolderName, loadDisconnectedProjects);
			return solution;
		}
	}
}