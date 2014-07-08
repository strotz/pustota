using Pustota.Maven.Serialization;
using Pustota.Maven.Serialization.Data;
using Pustota.Maven.System;

namespace Pustota.Maven
{
	public class SolutionManagement
	{
		public ISolution OpenSolution(string fileOrFolderName)
		{
			FileSystemAccess fileIo = new FileSystemAccess();
			IDataFactory factory = new DataFactory();
			IProjectSerializer serializer = new ProjectSerializer(factory);
			IProjectReader reader = new ProjectLoader(fileIo, serializer);
			var loader = new ProjectTreeLoader(fileIo, reader);

			var solution = new Solution(fileIo, loader);
			solution.Open(fileOrFolderName);
			return solution;
		}
	}
}