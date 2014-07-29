using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Externals;

namespace Pustota.Maven.Validation
{
	class RepositoryValidator
	{
		private readonly IProjectValidationFactory _factory;

		internal RepositoryValidator(IProjectValidationFactory factory)
		{
			_factory = factory;
		}

		public IEnumerable<ValidationProblem> Validate(ValidationContext context)
		{
			var validators = _factory.BuildProjectValidationSequence().ToArray();

			var problems = new List<ValidationProblem>();

			foreach (var project in context.Repository.AllProjects)
			{
				foreach (var validator in validators)
				{
					var result = validator.Validate(context, project).ToArray();
					problems.AddRange(result);

					if (result.Any(r => r.Severity == ProblemSeverity.ProjectFatal)) // does not make sense to contrinue with project
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