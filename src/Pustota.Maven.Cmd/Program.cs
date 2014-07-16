using System;

namespace Pustota.Maven.Cmd
{
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

			var options = new Options(); // TODO: seems lioke it is going to be refactoring with commandLine library, wiring will be fixed later
			if (!CommandLine.Parser.Default.ParseArgumentsStrict(args, options,
				(verb, subOptions) =>
				{
					invokedVerb = verb;
				}))
			{
				Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
			}

			options.ExecuteVerb(invokedVerb);
		}
	}
}
