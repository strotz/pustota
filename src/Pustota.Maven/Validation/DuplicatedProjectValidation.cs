using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	// TODO: TEST
	class DuplicatedProjectValidation : IProjectValidator
	{
		public IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			var extractor = new ProjectDataExtractor();
			var extracted = extractor.Extract(project);
			var operation = extracted.ReferenceOperations();

			var potencial = context.AllProjects
				.Where(p => p != project)
				.Select(extractor.Extract)
				.Where(pe => operation.ReferenceEqualTo(pe));

			var external = context.AllExternalModules
				.Where(ex => operation.ReferenceEqualTo(ex));

			return potencial
				.Concat(external)
				.Select(failed => new ValidationProblem("duplication")
			{
				ProjectReference = project,
				Severity = ProblemSeverity.ProjectFatal,
				Description = string.Format("duplication {0}", failed)
			});
		}
	}
}
