using System;
using System.Linq;
using Pustota.Maven.System;

namespace Pustota.Maven.Cmd
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				if (args.Length != 1)
				{
					Console.WriteLine("Need top folder location");
					return;
				}

				string topFolder = args[0];

				var solutionManagement = new SolutionManagement();
				var solution = solutionManagement.OpenSolution(topFolder);

				Console.WriteLine(solution.AllProjects.Count() + " projects loaded");

				solution.ForceSaveAll();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}
	}
}
