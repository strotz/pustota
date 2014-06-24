using System.Collections.Generic;

namespace Pustota.Maven
{
	public interface ISolution // REVIEW: has all
	{
		// REVIEW: support many RepositoryEntryPoint

		string BaseDir { get; }

		// string FullPath { get; }

		//IProjectsRepository ProjectsRepository { get; }

		//ProjectsValidations Validations { get; } // REVIEW: encapsulate
		//ExternalModulesRepository ExternalModules { get; } // REVIEW: encapsulate

		//void Reload(); // REVIEW: delete it

		//IEnumerable<ValidationError> Validate();

		//bool Changed { get; }
	}
}