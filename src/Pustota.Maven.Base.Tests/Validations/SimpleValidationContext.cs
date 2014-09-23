using System.Collections.Generic;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;
using Pustota.Maven.Validation.Data;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class SimpleValidationContext : IValidationContext
	{
		public IProjectsRepository Repository { get; set; }

		public IExternalModulesRepository ExternalModules { get; set; }

		public IEnumerable<IProject> AllProjects
		{
			get { return Repository.AllProjects; }
		}

		public IResolvedProjectData GetResolvedData(IProject project)
		{
			return Loader.Resolve(project); // REVIEW: should test Loader and validation separatelly  
		}
	}
}