using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Actions
{
	public class BulkSwitchToReleaseAction
	{
		private readonly IProjectsRepository _projects;
		private readonly string _postfix;

		public BulkSwitchToReleaseAction(IProjectsRepository projects, string postfix)
		{
			_projects = projects;
			_postfix = postfix;
		}

		public void Execute()
		{
			foreach (var project in _projects.AllProjects.Where(pn => pn.Version.IsSnapshot))
			{
				project.Version.SwitchToRelease();
				project.Version.AddPostfix(_postfix);
				foreach (var dependentProject in _projects.AllProjects)
				{
					dependentProject.Operations().PropagateVersionToUsages(project);
				}
			}
		}
	}
}