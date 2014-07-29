using System;
using Pustota.Maven.Externals;

namespace Pustota.Maven.Validation
{
	class RepositortValidator
	{
		private readonly IProjectsRepository _repository;
		private readonly IExternalModulesRepository _externalModules;

		internal RepositortValidator(IProjectsRepository repository, IExternalModulesRepository externalModules)
		{
			_repository = repository;
			_externalModules = externalModules;
		}

		public void Validate()
		{
			//ValidationLoop();

			//ValidateProjects();
			//ValidateDependencies();
			//ValidateModules();
			//ValidateExternalModules();
		}

		private bool ValidationLoop()
		{
			bool fail = false; // REVIEW: do something more readable
			//foreach (ProjectNode node in _repository.AllProjectNodes)
			//{
			//	foreach (var validation in BuildValidationSequence(node))
			//	{
			//		var validationResult = validation.Validate();
			//		if (validationResult == ValidationResult.ProjectFatal)
			//		{
			//			fail = true;
			//			break;
			//		}
			//	}
			//}
			throw new NotImplementedException();

			return fail;
		}
	}
}