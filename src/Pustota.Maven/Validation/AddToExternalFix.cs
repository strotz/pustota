using System;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class AddToExternalFix : Fix
	{
		private readonly IExternalModulesRepository _externalModules;
		private readonly IProjectReference _externalReference;

		internal AddToExternalFix(IExternalModulesRepository externalModules, IProjectReference externalReference)
		{
			_externalModules = externalModules;
			_externalReference = externalReference;

			ShouldBeConfirmed = true;
			Title = "Mark as external module";
		}

		public override void Do()
		{
			throw new NotImplementedException();

			//var module = new ExternalModule(_externalReference, string.Empty);
			//_externalModules.Add(module);
			//_externalModules.AllModules.Save();
		}
	}
}