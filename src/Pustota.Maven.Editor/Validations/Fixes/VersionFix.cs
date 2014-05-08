using Pustota.Maven.Editor.Models;

namespace Pustota.Maven.Editor.Validations.Fixes
{
	internal class VersionFix : Fix
	{
		private readonly Project _project;
		private readonly IProjectReference _reference;
		private readonly string _version;

		public VersionFix(Project project, IProjectReference reference, string version)
		{
			_project = project;
			_reference = reference;
			_version = version;

			Title = string.Format("version will be changed to {0}", version);
		}

		public override void Do()
		{
			_reference.Version = _version;
			_project.Changed = true; // REVIEW: project should be notified
		}
	}
}