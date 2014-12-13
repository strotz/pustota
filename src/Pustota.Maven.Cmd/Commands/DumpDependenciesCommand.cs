using System;
using Pustota.Maven.Actions;

namespace Pustota.Maven.Cmd.Commands
{
	internal class DumpDependenciesCommand :
		RepoBased,
		ICommand
	{
		public void Execute()
		{
			var solutionManagement = new SolutionManagement(GetActionLog());
			var solution = solutionManagement.OpenSolution(Path, LoadAllProjects);

			DumpDependenciesAction action = new DumpDependenciesAction(solution);
			var result = action.Execute();

			foreach (string classifier in result)
			{
				Console.WriteLine(classifier);
			}
		}
	}
}
