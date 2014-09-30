using System.Collections.Generic;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Actions
{
	public class ValidateTreeStructureAction
	{
		private readonly IExecutionContext _context;

		public ValidateTreeStructureAction(IExecutionContext context)
		{
			_context = context;
		}

		public IEnumerable<IProjectValidationProblem> Execute()
		{
			var validationFactory = new ValidationFactory(); 
			RepositoryValidator validator = new RepositoryValidator(validationFactory);
			return validator.Validate(_context);
		}
	}
}
