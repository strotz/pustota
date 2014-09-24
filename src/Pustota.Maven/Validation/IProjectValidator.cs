using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	public interface IProjectValidator
	{
		IEnumerable<ValidationProblem> Validate(IExecutionContext context, IProject project);
	}
}