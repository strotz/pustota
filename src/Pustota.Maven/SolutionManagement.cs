using System;
using Pustota.Maven.Externals;
using Pustota.Maven.Serialization;
using Pustota.Maven.Serialization.Data;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven
{
	public class SolutionManagement
	{
		public IActionLog Log { get; private set; }

		public SolutionManagement()
		{
			Log = NoLog.Instance;
		}

		public SolutionManagement(IActionLog log)
		{
			if (log == null)
				throw new ArgumentNullException("log");

			Log = log;
		}

		public ISolution OpenSolution(string fileOrFolderName, bool loadDisconnectedProjects)
		{
			IFileSystemAccess fileIo = new FileSystemAccess();
			IDataFactory factory = new DataFactory();
			IProjectSerializerWithUpdate serializer = new ProjectSerializer(factory);
			IProjectLoader projectLoader = new ProjectLoader(fileIo, serializer, Log);

			var pathCalculator = new PathCalculator(fileIo);
			var loader = new ProjectTreeLoader(fileIo, projectLoader, projectLoader, pathCalculator, Log);

			IExternalModulesLoader externalModulesLoader = new ExternalModulesLoader(fileIo);

			var solution = new Solution(fileIo, loader, externalModulesLoader);
			solution.Open(fileOrFolderName, loadDisconnectedProjects);
			return solution;
		}
	}
}