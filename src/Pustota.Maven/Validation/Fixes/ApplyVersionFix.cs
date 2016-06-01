using Pustota.Maven.Models;

namespace Pustota.Maven.Validation.Fixes
{
	// REVIEW: 
	internal class ApplyVersionFix : Fix
	{
		private readonly IProjectReference _reference;
		private readonly ComponentVersion _version;

		public ApplyVersionFix(IProjectReference reference, ComponentVersion version)
		{
			_reference = reference;
			_version = version;

			Title = $"version will be changed to {version}";
		}

		public override void Do()
		{
			_reference.Version = _version;
			// _project.Changed = true; // REVIEW: project should be notified
		}
	}
}