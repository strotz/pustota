namespace Pustota.Maven
{
	// REVIEW: has all
	public interface ISolution : IProjectsRepository
	{
		// REVIEW: support many RepositoryEntryPoint

		string BaseDir { get; }

		// string FullPath { get; }

		//ProjectsValidations Validations { get; } // REVIEW: encapsulate
		//ExternalModulesRepository ExternalModules { get; } // REVIEW: encapsulate

		//void Reload(); // REVIEW: delete it

		//IEnumerable<ValidationError> Validate();

		//bool Changed { get; }

		void ForceSaveAll();
	}
}