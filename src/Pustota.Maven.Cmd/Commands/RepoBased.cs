using System;
using CommandLine;

namespace Pustota.Maven.Cmd.Commands
{
	internal class RepoBased
	{
		internal RepoBased()
		{
			Path = Environment.CurrentDirectory;
		}

		[Option('p', "path", HelpText = "Path to repository")]
		public string Path { get; set; }
	}
}