using System;
using System.Diagnostics;
using System.Linq;
using CommandLine;
using Pustota.Maven.Actions;
using Pustota.Maven.Models;

namespace Pustota.Maven.Cmd.Commands
{
	internal class EnableSnapshotCommand :
		RepoBased,
		ICommand
	{
		[Option('g', "groupId", HelpText = "Project groupId")]
		public string GroupId { get; set; }

		[Option('a', "artifactId", HelpText = "Project artifactId")]
		public string ArtifactId { get; set; }

		[Option('v', "version", HelpText = "Project version")]
		public string Version { get; set; }

		[Option("position", DefaultValue = -1, HelpText = "Position of number to increment")]
		public int Position { get; set; }

		// TODO: use current folder to identify project if current folder is under repo

		public void Execute()
		{
			var solutionManagement = new SolutionManagement(GetActionLog());
			var solution = solutionManagement.OpenSolution(Path, LoadAllProjects);
			
			IProject target;
			if (!solution.TryGetProject(GroupId, ArtifactId, Version, out target, !string.IsNullOrEmpty(Version)))
			{
				Console.Error.WriteLine("Could not find project");	
				return;
			}

			Console.WriteLine("Switch to SNAPSHOT project {0} and all dependent in folder {1}", target, Path);
			if (Position != -1)
			{
				Console.WriteLine($"Increment {Position} position");
			}
			else
			{
				Console.WriteLine("Increment last version position");
			}

			Debug.WriteLine(solution.AllProjects.Count() + " projects loaded");

			CascadeSwitchAction cascade = new CascadeSwitchAction(solution);
			int? position = null;
			if (Position >= 0)
			{
				position = Position;
			}
			 
			cascade.ExecuteFor(target, position);

			solution.ForceSaveAll();
		}
	}
}
