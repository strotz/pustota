using Pustota.Maven.Editor.Models;
using Pustota.Maven.Editor.Resources;

namespace Pustota.Maven.Editor.Validations.Fixes
{
	internal class RelativePathFix : Fix
	{
		private readonly Project _project;
		private readonly string _parentPath;

		internal RelativePathFix(Project project, string parentPath)
		{
			_project = project;
			_parentPath = parentPath;

			Title = MessageResources.FixRelativePath;
		}

		public override void Do()
		{
			_project.Parent.RelativePath = _parentPath;
			_project.Changed = true; // REVIEW: project should be notified
		}
	}
}
