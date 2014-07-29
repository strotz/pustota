using Pustota.Maven.Actions;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation.Fixes
{
	internal class SwitchToSnapshotFix : Fix
	{
		private readonly IProjectsRepository _projectsRepo;
		private readonly IProject _project;

		public SwitchToSnapshotFix(IProjectsRepository projectsRepo, IProject project)
		{
			_projectsRepo = projectsRepo;
			_project = project;

			Title = "Switch this and all dependent projects to SNAPSHOT";
		}

		public override void Do()
		{
			var action = new CascadeSwitchAction(_projectsRepo);
			action.ExecuteFor(_project);
		}
	}
}