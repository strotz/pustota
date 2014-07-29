using System.Collections.Generic;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	// REVIEW: interface
	class ValidationFactory
	{
		private readonly IProjectsRepository _repository;
		private readonly IExternalModulesRepository _externalModules;

		public ValidationFactory(IProjectsRepository repository, IExternalModulesRepository externalModules)
		{
			_repository = repository;
			_externalModules = externalModules;
		}

		internal IEnumerable<IValidation> BuildValidationSequence(IProject project)
		{
			yield return new ParentSpecificVersionValidation(project);
			yield return new ProjectSpecificVersionValidation(project);
			yield return new DuplicatedProjectValidation(project, _repository);
			yield return new ParentReferenceExistValidation(project, _repository, _externalModules);
			yield return new ProjectPluginVersionsValidation(project, _repository, _externalModules);
			yield return new ProjecModulesValidation(project);
		}

		internal IEnumerable<IValidation> BuildValidationSequence(IExternalModule module)
		{
			yield return new UselessExternalModulesValidation(module, _repository, _externalModules);
		}
	}
}