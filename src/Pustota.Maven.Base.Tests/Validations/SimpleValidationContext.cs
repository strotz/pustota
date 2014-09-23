using System.Collections.Generic;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class SimpleValidationContext : IValidationContext
	{
		private readonly IDictionary<IProject, IResolvedProjectData> _resolved;

		public SimpleValidationContext()
		{
			_resolved = new Dictionary<IProject, IResolvedProjectData>();
		}

		public IProjectsRepository Repository { get; set; }

		public IExternalModulesRepository ExternalModules { get; set; }

		public IEnumerable<IProject> AllProjects
		{
			get { return Repository.AllProjects; }
		}

		public IDictionary<IProject, IResolvedProjectData> Resolved
		{
			get { return _resolved; }
		}
	}
}