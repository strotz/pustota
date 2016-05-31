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
			Build = null;
		}

		[Option('s', "suffix", HelpText = "Suffix to apply to release")]
		public string Suffix { get; set; }

		[Option('b', "build", HelpText = "Build number for semantic versioning, will be applied before suffix")]
		public long? Build { get; set; }

		// TODO: DryRun? 

		public void Execute()
		{
			Console.WriteLine("Release for all SNAPSHOT projects in folder {0} with build {2} and \"{1}\" suffix", Path, Suffix, Build);

			var solutionManagement = new SolutionManagement(GetActionLog());
			var solution = solutionManagement.OpenSolution(Path, LoadAllProjects);

			Debug.WriteLine(solution.AllProjects.Count() + " projects loaded");

			BulkSwitchToReleaseAction action = new BulkSwitchToReleaseAction(solution, Suffix, Build);
			action.Execute();

			solution.ForceSaveAll();
		}
	}
}
