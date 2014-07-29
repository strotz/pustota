using System.Collections.Generic;

namespace Pustota.Maven.Validation
{
	public interface IRepositoryValidationFactory
	{
		IEnumerable<IRepositoryValidator> BuildRepositoryValidationSequence();
	}
}