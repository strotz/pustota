using System;
using System.Diagnostics;
using System.Linq;
using CommandLine;
using Pustota.Maven.Actions;
using Pustota.Maven.Models;

namespace Pustota.Maven.Cmd.Commands
{
	internal class ReleaseAllCommand : 
		RepoBased,
		ICommand
	{
		internal ReleaseAllCommand()
		{
			Suffix = string.Empty;
		    VersionString = string.Empty; 
			Build = null;
		}

		[Option('s', "suffix", HelpText = "Suffix to apply to release")]
		public string Suffix { get; set; }

		[Option('b', "build", HelpText = "Build number for semantic versioning, will be applied before suffix")]
		public long? Build { get; set; }

        [Option('r', "release", HelpText = "Complete release version. Suffix and build are going to be ignored if version is specified. Release version must be extension of snapshot version otherwise project will not be released.")]
        public string VersionString { get; set; }

        // TODO: DryRun? 

        public void Execute()
        {
            var version = ComponentVersion.Undefined;
            if (!String.IsNullOrEmpty(VersionString))
            {
                Console.WriteLine("Release for all SNAPSHOT projects in folder {0} to release version {1}", Path, VersionString);
                version = new ComponentVersion(VersionString);
            }
            else
            {
                Console.WriteLine("Release for all SNAPSHOT projects in folder {0} with build {1} and \"{2}\" suffix", Path, Build, Suffix);
            }

            var solutionManagement = new SolutionManagement(GetActionLog());
			var solution = solutionManagement.OpenSolution(Path, LoadAllProjects);

			Debug.WriteLine(solution.AllProjects.Count() + " projects loaded");

			BulkSwitchToReleaseAction action = version.IsDefined ?
                new BulkSwitchToReleaseAction(solution, version) :
                new BulkSwitchToReleaseAction(solution, Build, Suffix);

			action.Execute();

			solution.ForceSaveAll();
		}
	}
}
