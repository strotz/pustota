using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	class DuplicatedExternalModulesValidation : IRepositoryValidator
	{
		public IEnumerable<IProjectValidationProblem> Validate(IExternalModuleRepository context)
		{
			foreach (var module in context.AllExternalModules)
			{
				var operation = module.ReferenceOperations();
				if (context.AllExternalModules.Count(m => operation.ReferenceEqualTo(m, true)) > 1)
				{
					yield return new ValidationProblem("moduleduplication")
					{
						ProjectReference = module,
						Description = "external module duplication",
						Severity = ProblemSeverity.ProjectWarning
					};
				}
			}
		}
	}
}