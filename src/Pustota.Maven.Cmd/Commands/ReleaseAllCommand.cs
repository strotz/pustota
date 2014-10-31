using System;
using System.Diagnostics;
using System.Linq;
using CommandLine;
using Pustota.Maven.Actions;

namespace Pustota.Maven.Cmd.Commands
{
	internal class ReleaseAllCommand : 
		RepoBased,
		ICommand
	{
		internal ReleaseAllCommand()
		{
			Suffix = string.Empty;
		}

		[Option('s', "suffix", HelpText = "Suffix to apply to release")]
		public string Suffix { get; set; }

		// TODO: DryRun? 

		public void Execute()
		{
			Console.WriteLine("Release for all SNAPSHOT projects in folder {0} with \"{1}\" suffix", Path, Suffix);

			var solutionManagement = new SolutionManagement(GetActionLog());
			var solution = solutionManagement.OpenSolution(Path, LoadAllProjects);

			Debug.WriteLine(solution.AllProjects.Count() + " projects loaded");

			BulkSwitchToReleaseAction action = new BulkSwitchToReleaseAction(solution, Suffix);
			action.Execute();

			solution.ForceSaveAll();
		}
	}
}
