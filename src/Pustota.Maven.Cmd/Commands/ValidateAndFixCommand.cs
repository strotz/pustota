using System;
using System.Linq;
using Pustota.Maven.Actions;

namespace Pustota.Maven.Cmd.Commands
{
	internal class ValidateAndFixCommand :
		RepoBased,
		ICommand
	{
		// TODO: DryRun

		public void Execute()
		{
			var solutionManagement = new SolutionManagement();
			var solution = solutionManagement.OpenSolution(Path, LoadAllProjects);

			ValidateTreeStructureAction action = new ValidateTreeStructureAction(solution);
			var problems = action.Execute().ToList();

			foreach (var problem in problems) 
			{
				Console.WriteLine(problem.Description);
			}

			Console.WriteLine("{0} projects validated", solution.AllProjects.Count());
			Console.WriteLine("{0} problems found", problems.Count());

			// TODO: need to save fixes solution.ForceSaveAll();
		}
	}
}
