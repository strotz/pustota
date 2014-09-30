using System;
using System.Linq;
using Pustota.Maven.Actions;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Cmd.Commands
{
	internal class ValidateAndFixCommand :
		RepoBased,
		ICommand
	{
		// TODO: DryRun

		public void Execute()
		{
			var solutionManagement = new SolutionManagement();
			var solution = solutionManagement.OpenSolution(Path, LoadAllProjects);

			ValidateTreeStructureAction action = new ValidateTreeStructureAction(solution);
			var problems = action.Execute().ToList();

			foreach (var problem in problems) 
			{
				Console.WriteLine("{0,-10} {1}\t{2}", GetTitle(problem), problem.ProjectReference, problem.Description);
			}

			Console.WriteLine("{0} projects validated", solution.AllProjects.Count());
			Console.WriteLine("{0} problems found", problems.Count());

			// TODO: need to save fixes solution.ForceSaveAll();
		}

		private static string GetTitle(IProjectValidationProblem problem)
		{
			switch (problem.Severity)
			{
				case ProblemSeverity.ProjectFatal:
					return "error:";
				case ProblemSeverity.ProjectWarning:
					return "warning:";
				default:
					return "Undefined:";
			}
		}
	}
}
