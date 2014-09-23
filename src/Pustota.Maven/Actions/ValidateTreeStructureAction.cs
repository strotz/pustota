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

			internal ValidationContext(IProjectsRepository projects)
			{
				_projects = projects;
			}

			public IEnumerable<IProject> AllProjects
			{
				get { return _projects.AllProjects; }
			}
		}

		private readonly IProjectsRepository _projects;

		public ValidateTreeStructureAction(IProjectsRepository projects)
		{
			_projects = projects;
		}

		public void Execute()
		{
			var validationFactory = new ValidationFactory(); 
			RepositoryValidator validator = new RepositoryValidator(validationFactory);
			var context = new ValidationContext(_projects); 
			var problems = validator.Validate(context);
			foreach (var problem in problems) // REVIEW: output must be provided by environment 
			{
				Console.WriteLine(problem.Description);
			}
		}
	}
}
