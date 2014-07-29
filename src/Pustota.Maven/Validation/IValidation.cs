using System.Collections.Generic;

namespace Pustota.Maven.Validation
{
	public interface IValidation
	{
		IEnumerable<ValidationProblem> Validate();
	}
}