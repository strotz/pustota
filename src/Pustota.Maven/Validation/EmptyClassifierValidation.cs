using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class EmptyClassifierValidation : IProjectValidator
	{
		public IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			foreach (var dependency in project.Operations().AllDependencies.Where(d => d.Classifier == string.Empty))
			{
				yield return new ValidationProblem("emptyclassifier")
				{
					ProjectReference = project,
					Description = "empty classifier",
					Severity = ProblemSeverity.ProjectWarning
				};
			}
		}
	}
}