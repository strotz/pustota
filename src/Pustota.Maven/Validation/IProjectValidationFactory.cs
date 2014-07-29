using System.Collections.Generic;

namespace Pustota.Maven.Validation
{
	public interface IProjectValidationFactory
	{
		IEnumerable<IProjectValidator> BuildProjectValidationSequence();
	}
}