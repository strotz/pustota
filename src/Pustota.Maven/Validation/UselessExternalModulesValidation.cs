using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pustota.Maven.Externals;

namespace Pustota.Maven.Validation
{
	class UselessExternalModulesValidation : IRepositoryValidator
	{
		public IEnumerable<ValidationProblem> Validate(IValidationContext context)
		{
			//foreach (var externalModule in context.ExternalModules.Items)
			//{
				//if (!_repository.IsItUsed(externalModule))
				//{
				//	ValidationError error = new ValidationError(
				//		externalModule,
				//		"The external module is not used",
				//		externalModule.ToString(), ErrorLevel.Info);

				//	ExternalModule module = externalModule;
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
			//}
			throw new NotImplementedException();
		}
	}
}
