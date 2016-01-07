using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

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
			var queue = new Queue<IProject>();
			var extractor = new ProjectDataExtractor();

			foreach (var project in _projects.AllProjects.Where(pn => pn.Version.IsSnapshot)) // first, deal with explicit version
			{
				project.Version = project.Version.SwitchSnapshotToRelease(_postfix);
				foreach (var dependentProject in _projects.AllProjects)
				{
					dependentProject.Operations().PropagateVersionToUsages(project);
					if (!dependentProject.Version.IsDefined 
						&& dependentProject.Operations().HasProjectAsParent(project))
					{
						queue.Enqueue(dependentProject);
					}
				}
			}

			while (queue.Count != 0) // handle queue of projects with inherited version, no need to switch, it is done already, only propagate
			{
				var project = queue.Dequeue();
				var projectReference = extractor.Extract(project);
				foreach (var dependentProject in _projects.AllProjects)
				{
					dependentProject.Operations().PropagateVersionToUsages(projectReference);
					if (!dependentProject.Version.IsDefined
						&& dependentProject.Operations().HasProjectAsParent(projectReference))
					{
						queue.Enqueue(dependentProject);
					}
				}
			}
		}
	}
}