using System;
using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Actions
{
	public class CascadeSwitchAction
	{
		private readonly IProjectsRepository _projects;

		public CascadeSwitchAction(IProjectsRepository projects)
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
			var extractor = new ProjectDataExtractor();

			var queue = new Queue<IProject>();
			queue.Enqueue(targetProject);

			while (queue.Count != 0)
			{
				var project = queue.Dequeue();

				if (project.Version.IsRelease) // explicit release
				{
					project.Version = project.Version.SwitchReleaseToSnapshotWithVersionIncrement();
				}
				else if (project.Version.IsSnapshot) // explicit snapshot, just propogate
				{
				}
				else if (!project.Version.IsDefined && project.Parent != null && project.Parent.Version.IsRelease) // inherited from release
				{
					project.Version = project.Parent.Version.SwitchReleaseToSnapshotWithVersionIncrement(); // make it explicit
				}
				else if (!project.Version.IsDefined && project.Parent != null && project.Parent.Version.IsSnapshot) // inherited from snapshot, just propogate
				{
				}
				else
				{
					throw new InvalidOperationException($"why project {project} in queue");
				}
				var reference = extractor.Extract(project);

				foreach (var dependentProject in selector.SelectUsages(reference))
				{
					dependentProject.Operations().PropagateVersionToUsages(reference);
					if (dependentProject.Operations().HasProjectAsParent(reference))
					{
						queue.Enqueue(dependentProject);
					}
				}
			}
		}
	}
}