using System;
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

		public IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context)
		{
			var validators = _factory.BuildProjectValidationSequence().ToArray();

			var problems = new List<IProjectValidationProblem>();

			foreach (var project in context.AllProjects)
			{
				foreach (var validator in validators)
				{
					try
					{
						var result = validator.Validate(context, project).ToArray();
						problems.AddRange(result);

						if (result.Any(r => r.Severity == ProblemSeverity.ProjectFatal)) // does not make sense to continue with project
						{
							break;
						}
					}
					catch (Exception ex)
					{
						var fatal = new ValidationProblem("fatal")
						{
							ProjectReference = project,
							Severity = ProblemSeverity.ProjectFatal,
							Description = string.Format("exception during validation {0}", ex)
						};

						problems.Add(fatal);
						return problems;
					}
				}
			}

			return problems;

			//ValidateModules();
			//ValidateExternalModules();
		}
	}
}