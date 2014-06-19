namespace Pustota.Maven
{
	internal class SolutionManagement
	{
		internal ISolution OpenSolution(string fileOrFolderName)
		{
			var solution = new Solution();
			solution.Open(fileOrFolderName);
			return solution;
		}
	}
}