﻿using System.Collections.Generic;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	// REVIEW: interface
	class ValidationFactory : 
		IProjectValidationFactory,
		IRepositoryValidationFactory
	{
		public IEnumerable<IProjectValidator> BuildProjectValidationSequence()
		{
			yield return new ParentSpecificVersionValidation();
			yield return new ProjectSpecificVersionValidation();
			yield return new DuplicatedProjectValidation();
			yield return new ParentReferenceExistValidation();
			yield return new ProjectPluginVersionsValidation();
			yield return new ProjecModulesValidation();
		}

		public IEnumerable<IRepositoryValidator> BuildRepositoryValidationSequence()
		{
			yield return new UselessExternalModulesValidation();
		}
	}
}