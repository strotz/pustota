using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Validation.Fixes
{
	internal class RelativePathFix : Fix
	{
		private readonly IProject _project;
		private readonly string _parentPath;

		internal RelativePathFix(Project project, string parentPath)
		{
			_project = project;
			_parentPath = parentPath;

			Title = "Correct relative path";
		}

		public override void Do()
		{
			_project.Parent.RelativePath = _parentPath;
			// _project.Changed = true; // REVIEW: project should be notified
		}
	}
}
