using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Pustota.Maven.Actions;

namespace Pustota.Maven.Cmd.Commands
{
	internal class ReleaseAllCommand : ICommand
	{
		internal ReleaseAllCommand()
		{
			Suffix = string.Empty;
			Path = Environment.CurrentDirectory;
		}

		[Option('s', "suffix", HelpText = "Suffix to apply to release")]
		public string Suffix { get; set; }

		[Option('p', "path", HelpText = "Path to repository")]
		public string Path { get; set; }

		// TODO: DryRun? 

		public void Execute()
		{
			Console.WriteLine("Release for all SNAPSHOT projects in folder {0} with  \"{1}\" suffix", Path, Suffix);

			var solutionManagement = new SolutionManagement();
			var solution = solutionManagement.OpenSolution(Path);

			Debug.WriteLine(solution.AllProjects.Count() + " projects loaded");

			BulkSwitchToReleaseAction action = new BulkSwitchToReleaseAction(solution, Suffix);
			action.Execute();

			solution.ForceSaveAll();
		}
	}
}
