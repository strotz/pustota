using System.Diagnostics;
using System.Linq;
using Pustota.Maven.Editor.Models;

namespace Pustota.Maven.Editor
{
	internal class BulkSwitchToReleaseAction
	{
		private readonly ProjectViewMap _views;
		private readonly IProjectsRepository _projects;
		private readonly string _postfix;

		public BulkSwitchToReleaseAction(ProjectViewMap views, IProjectsRepository projects, string postfix)
		{
			_views = views;
			_projects = projects;
			_postfix = postfix;
		}

		public void Execute()
		{
			var searchOptions = new SearchOptions
			{
				LookForDependent = true,
				LookForParents = true,
				LookForPlugin = true,
				OnlyDirectUsages = true,
				StrictVersion = false
			};

			var selector = new DependencySelector(_projects, searchOptions);

			foreach (var projectNode in _projects.AllProjectNodes.Where(pn => pn.IsSnapshot))
			{
				projectNode.SwitchToRelease(_postfix);
				foreach (var dependentProject in selector.SelectUsages(projectNode))
				{
					dependentProject.PropagateVersionToUsages(projectNode.Project);
				}
			}
		}
	}
}