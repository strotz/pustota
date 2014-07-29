using System;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation.Fixes
{
	internal class DeleteExternalModuleFix : Fix
	{
		private readonly IExternalModulesRepository _externalModules;
		private readonly IProjectReference _externalReference;

		internal DeleteExternalModuleFix(IExternalModulesRepository externalModules, IProjectReference externalReference)
		{
			_externalModules = externalModules;
			_externalReference = externalReference;

			ShouldBeConfirmed = true;
			Title = "Delete external module";
		}

		public override void Do()
		{
			throw new NotImplementedException();

			//var module = new ExternalModule(_externalReference, string.Empty);
			//_externalModules.Remove(module);
			//_externalModules.AllModules.Save();
		}
	}
}