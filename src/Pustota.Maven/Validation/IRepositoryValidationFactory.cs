using System.Collections.Generic;

namespace Pustota.Maven.Validation
{
	public interface IRepositoryValidationFactory : IProjectValidationFactory
	{
		IEnumerable<IRepositoryValidator> BuildRepositoryValidationSequence();
	}
}