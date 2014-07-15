using System;
using System.Linq;
using Pustota.Maven.Actions;

namespace Pustota.Maven.Cmd
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				if (args.Length > 2)
				{
					PrintUsage();
					return;
				}

				string topFolder = args.Length > 0 ? args[0] : Environment.CurrentDirectory;
				string postfix = args.Length > 1 ? args[1] : string.Empty;

				var solutionManagement = new SolutionManagement();
				var solution = solutionManagement.OpenSolution(topFolder);

				Console.WriteLine(solution.AllProjects.Count() + " projects loaded");

				BulkSwitchToReleaseAction action = new BulkSwitchToReleaseAction(solution, postfix);
				action.Execute();

				solution.ForceSaveAll();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}

		private static void PrintUsage()
		{
			Console.WriteLine("exe <pathtofolder> <postfix>");
		}
	}
}
