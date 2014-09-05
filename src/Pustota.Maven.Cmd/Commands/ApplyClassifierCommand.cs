using System;
using CommandLine;
using Pustota.Maven.Actions;

namespace Pustota.Maven.Cmd.Commands
{
	internal class ApplyClassifierCommand :
		RepoBased,
		ICommand
	{
		[ValueOption(0)] // TODO: better integration with parser
		public string Data { get; set; }

		public void Execute()
		{
			if (Data == null || !Data.Contains("="))
			{
				Console.Error.WriteLine("Define name=value parameter");
				return;
			}

			var split = Data.Split(new[] {'='});
			if (split.Length != 2)
			{
				Console.Error.WriteLine("Define name=value parameter");
				return;
			}

			string name = split[0];
			string value = split[1];
			Console.WriteLine("Apply value \"{0}\" to property \"{1}\"", value, name);

			var solutionManagement = new SolutionManagement();
			var solution = solutionManagement.OpenSolution(Path, LoadAllProjects);

			ApplyClassifierAction action = new ApplyClassifierAction(solution, name, value);
			action.Execute();

			solution.ForceSaveAll();
		}
	}
}