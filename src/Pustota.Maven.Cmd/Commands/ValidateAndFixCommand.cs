using System.Diagnostics;
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

			Debug.WriteLine(solution.AllProjects.Count() + " projects loaded");

			ValidateTreeStructureAction action = new ValidateTreeStructureAction(solution);
			action.Execute();

			// solution.ForceSaveAll();
		}
	}
}
