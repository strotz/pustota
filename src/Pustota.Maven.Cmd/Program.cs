using System;
using CommandLine;
using CommandLine.Text;
using Pustota.Maven.Cmd.Commands;

namespace Pustota.Maven.Cmd
{
	class Options
	{
		public Options()
		{
			// Since we create this instance the parser will not overwrite it
			ReleaseAllCommand = new ReleaseAllCommand();
		}

		[VerbOption("releaseAll", HelpText = "Release all snapshot projects in repo")]
		public ReleaseAllCommand ReleaseAllCommand { get; set; }

		[HelpVerbOption]
		public string GetUsage(string verb)
		{
			return HelpText.AutoBuild(this, verb);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				ParseAndExecuteCommands(args);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		internal static void ParseAndExecuteCommands(string[] args)
		{
			string invokedVerb = null;
			object invokedVerbInstance = null;

			var options = new Options(); // TODO: seems lioke it is going to be refactoring with commandLine library, wiring will be fixed later
			if (!CommandLine.Parser.Default.ParseArguments(args, options,
				(verb, subOptions) =>
				{
					invokedVerb = verb;
					invokedVerbInstance = subOptions;
				}))
			{
				Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
			}

			if (invokedVerb == "releaseAll")
			{
				var releaseAllCommand = (ReleaseAllCommand) invokedVerbInstance;
				releaseAllCommand.Execute();
			}
		}
	}
}
