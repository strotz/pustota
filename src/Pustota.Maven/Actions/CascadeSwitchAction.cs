using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Actions
{
	internal class CascadeSwitchAction
	{
		private readonly IProjectsRepository _projects;

		internal CascadeSwitchAction(IProjectsRepository projects)
		{
			_projects = projects;
		}

		public void ExecuteFor(IProject targetProject)
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

			var queue = new Queue<IProject>();
			queue.Enqueue(targetProject);

			while (queue.Count != 0)
			{
				var project = queue.Dequeue();
				if (!project.ReferenceOperations().IsSnapshot)
				{
					project.ReferenceOperations().SwitchToSnapshotWithVersionIncrement();
				}

				foreach (var dependentProject in selector.SelectUsages(project))
				{
					dependentProject.Operations().PropagateVersionToUsages(project);
					if (!dependentProject.ReferenceOperations().IsSnapshot)
					{
						queue.Enqueue(dependentProject);
					}
				}
			}
		}
	}
}