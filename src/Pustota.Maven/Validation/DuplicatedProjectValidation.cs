using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	// TODO: TEST
	class DuplicatedProjectValidation : IProjectValidator
	{
		public IEnumerable<IValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			var extractor = new ProjectDataExtractor();
			var extracted = extractor.Extract(project);
			var operation = extracted.ReferenceOperations();

			var potencial = context.AllProjects
				.Where(p => p != project)
				.Where(p =>
				{
					var pe = extractor.Extract(p);
					return operation.ReferenceEqualTo(pe);
				});

			return potencial.Select(failed => new ValidationProblem
			{
				Severity = ProblemSeverity.ProjectFatal,
				Description = string.Format("Project {0} has duplication {1}", project, failed)
			});
		}
	}
}
