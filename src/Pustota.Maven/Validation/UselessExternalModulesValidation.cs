using System.Collections.Generic;
using System.Linq;

namespace Pustota.Maven.Validation
{
	class UselessExternalModulesValidation : IRepositoryValidator
	{
		public IEnumerable<IProjectValidationProblem> Validate(IExecutionContext context)
		{
			var searchOptions = new SearchOptions
			{
				LookForDependent = true,
				LookForParents = true,
				LookForPlugin = true,
				OnlyDirectUsages = true,
				StrictVersion = true
			};

			var selector = new DependencySelector(context, searchOptions);

			foreach (var module in context.AllExternalModules)
			{
				if (!selector.SelectUsages(module).Any())
				{
					yield return new ValidationProblem("moduleuseless")
					{
						ProjectReference = module,
						Description = "external module not used",
						Severity = ProblemSeverity.ProjectWarning
					};
				}
				//	DelegatedFix fix = new DelegatedFix
				//	{
				//		ShouldBeConfirmed = true,
				//		Title = "Delete external module",
				//		DelegatedAction = () =>
				//		{
				//			_externalModules.Remove(module);
				//			_externalModules.AllModules.Save();
				//		}
				//	};
				//	error.AddFix(fix);
				//	ValidationErrors.Add(error);
				//}
			}
		}
	}
}
