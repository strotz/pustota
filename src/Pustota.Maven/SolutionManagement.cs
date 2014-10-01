using Pustota.Maven.Externals;
using Pustota.Maven.Serialization;
using Pustota.Maven.Serialization.Data;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven
{
	public class SolutionManagement
	{
		public ISolution OpenSolution(string fileOrFolderName, bool loadDisconnectedProjects)
		{
			IFileSystemAccess fileIo = new FileSystemAccess();
			IDataFactory factory = new DataFactory();
			IProjectSerializerWithUpdate serializer = new ProjectSerializer(factory);
			IProjectLoader projectLoader = new ProjectLoader(fileIo, serializer);
			var loader = new ProjectTreeLoader(fileIo, projectLoader, projectLoader);

			IExternalModulesController externalModulesController = new ExternalModulesLoader(fileIo);

			var solution = new Solution(fileIo, loader, externalModulesController);
			solution.Open(fileOrFolderName, loadDisconnectedProjects);
			return solution;
		}
	}
}