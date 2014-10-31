using System;
using Pustota.Maven.Actions;

namespace Pustota.Maven.Cmd.Commands
{
	internal class DumpClassifiersCommand : 
		RepoBased,
		ICommand
	{
		public void Execute()
		{
			var solutionManagement = new SolutionManagement(GetActionLog());
			var solution = solutionManagement.OpenSolution(Path, LoadAllProjects);

			DumpClassifiersAction action = new DumpClassifiersAction(solution);
			var result = action.Execute();

			foreach (string classifier in result)
			{
				Console.WriteLine(classifier);
			}
		}
	}
}