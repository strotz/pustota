using System;
using System.Diagnostics;
using System.Linq;

namespace Pustota.Maven.Cmd.Commands
{
	internal class NormalizeCommand :
		RepoBased,
		ICommand
	{
		public void Execute()
		{
			Console.WriteLine("Normalizing format for all projects in folder {0}", Path);

			var solutionManagement = new SolutionManagement(GetActionLog());
			var solution = solutionManagement.OpenSolution(Path, LoadAllProjects);

			Debug.WriteLine(solution.AllProjects.Count() + " projects loaded");

			solution.ForceSaveAll();
		}
	}
}