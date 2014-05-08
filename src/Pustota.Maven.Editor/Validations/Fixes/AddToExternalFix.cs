using Pustota.Maven.Editor.Externals;
using Pustota.Maven.Editor.Models;

namespace Pustota.Maven.Editor.Validations.Fixes
{
	internal class AddToExternalFix : Fix
	{
		private readonly ExternalModulesRepository _externalModules;
		private readonly IProjectReference _externalReference;

		internal AddToExternalFix(ExternalModulesRepository externalModules, IProjectReference externalReference)
		{
			_externalModules = externalModules;
			_externalReference = externalReference;

			ShouldBeConfirmed = true;
			Title = "Mark as external module";
		}

		public override void Do()
		{
			var module = new ExternalModule(_externalReference, string.Empty);
			_externalModules.Add(module);
			_externalModules.AllModules.Save();
		}
	}
}