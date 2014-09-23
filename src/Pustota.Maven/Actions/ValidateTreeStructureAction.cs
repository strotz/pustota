using System;
using System.Collections.Generic;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Actions
{
	public class ValidateTreeStructureAction
	{
		class ValidationContext : IValidationContext
		{
			private readonly IProjectsRepository _projects;
			private readonly IDictionary<IProject, IResolvedProjectData> _resolved;

			internal ValidationContext(IProjectsRepository projects)
			{
				_projects = projects;
				_resolved = new Dictionary<IProject, IResolvedProjectData>();
			}

			public IEnumerable<IProject> AllProjects
			{
				get { return _projects.AllProjects; }
			}

			public IDictionary<IProject, IResolvedProjectData> Resolved
			{
				get { return _resolved; }
			}
		}

		private readonly IProjectsRepository _projects;

		public ValidateTreeStructureAction(IProjectsRepository projects)
		{
			_projects = projects;
		}

		public IEnumerable<IValidationProblem> Execute()
		{
			var validationFactory = new ValidationFactory(); 
			RepositoryValidator validator = new RepositoryValidator(validationFactory);
			var context = new ValidationContext(_projects); 
			return validator.Validate(context);
		}
	}
}
