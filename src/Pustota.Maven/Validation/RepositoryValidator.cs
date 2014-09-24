using System.Collections.Generic;
using System.Linq;

namespace Pustota.Maven.Validation
{
	class RepositoryValidator
	{
		private readonly IProjectValidationFactory _factory;

		internal RepositoryValidator(IProjectValidationFactory factory)
		{
			_factory = factory;
		}

		public IEnumerable<ValidationProblem> Validate(IExecutionContext context)
		{
			var validators = _factory.BuildProjectValidationSequence().ToArray();

			var problems = new List<ValidationProblem>();

			foreach (var project in context.AllProjects)
			{
				foreach (var validator in validators)
				{
					var result = validator.Validate(context, project).ToArray();
					problems.AddRange(result);

					if (result.Any(r => r.Severity == ProblemSeverity.ProjectFatal)) // does not make sense to continue with project
					{
						break; 
					}
				}
			}

			return problems;

			//ValidateProjects();
			//ValidateDependencies();
			//ValidateModules();
			//ValidateExternalModules();
		}
	}
}