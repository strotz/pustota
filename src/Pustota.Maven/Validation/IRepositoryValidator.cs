using System.Collections.Generic;

namespace Pustota.Maven.Validation
{
	public interface IRepositoryValidator
	{
		IEnumerable<ValidationProblem> Validate(IExecutionContext context);
	}
}