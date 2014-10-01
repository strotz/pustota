using System.Collections.Generic;

namespace Pustota.Maven.Validation
{
	public interface IRepositoryValidator
	{
		IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context);
	}
}