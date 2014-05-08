using System.Collections.Generic;
using Pustota.Maven.Editor.Models;

namespace Pustota.Maven.Editor.Actions
{
	internal class CascadeSwitchAction
	{
		private readonly IProjectsRepository _projects;

		internal CascadeSwitchAction(IProjectsRepository projects)
		{
			_projects = projects;
		}

		public void ExecuteFor(ProjectNode currentProjectNode)
		{
			// var selected = _views.AllViews.Where(v => v.Checked).Select(v => v.ProjectNode);
			var searchOptions = new SearchOptions
			{
				LookForDependent = true,
				LookForParents = true,
				LookForPlugin = true,
				OnlyDirectUsages = true,
				StrictVersion = false
			};

			var selector = new DependencySelector(_projects, searchOptions);

			var queue = new Queue<ProjectNode>();
			queue.Enqueue(currentProjectNode);

			while (queue.Count != 0)
			{
				var projectNode = queue.Dequeue();
				if (!projectNode.IsSnapshot)
				{
					projectNode.IncrementVersionAndEnableSnapshot();
				}

				foreach (var dependentProject in selector.SelectUsages(projectNode))
				{
					dependentProject.PropagateVersionToUsages(projectNode.Project);
					if (!dependentProject.IsSnapshot)
					{
						queue.Enqueue(dependentProject);
					}
				}
			}

			// fix tree
		}
	}
}