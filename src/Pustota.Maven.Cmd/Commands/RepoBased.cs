using System;
using CommandLine;

namespace Pustota.Maven.Cmd.Commands
{
	internal class RepoBased : CommandBase
	{
		internal RepoBased()
		{
			Path = Environment.CurrentDirectory;
		}

		[Option('p', "path", HelpText = "Path to repository")]
		public string Path { get; set; }

		[Option('t', "tree", DefaultValue = false, HelpText = "Load all projects in the tree, even there is no module references")]
		public bool LoadAllProjects { get; set; }
	}
}