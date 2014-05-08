using Pustota.Maven.Editor.Actions;
using Pustota.Maven.Editor.Models;

namespace Pustota.Maven.Editor.Validations.Fixes
{
	internal class SwitchToSnapshotFix : Fix
	{
		private readonly IProjectsRepository _projectsRepo;
		private readonly ProjectNode _projectNode;

		public SwitchToSnapshotFix(IProjectsRepository projectsRepo, ProjectNode projectNode)
		{
			_projectsRepo = projectsRepo;
			_projectNode = projectNode;

			Title = "Switch this and all dependent projects to SNAPSHOT";
		}

		public override void Do()
		{
			var action = new CascadeSwitchAction(_projectsRepo);
			action.ExecuteFor(_projectNode);
		}
	}
}