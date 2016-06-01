using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Actions
{
	public class BulkSwitchToReleaseAction
	{
		private readonly IProjectsRepository _projects;
	    private readonly ComponentVersion _version;
	    private readonly long? _build;
		private readonly string _postfix;

		public BulkSwitchToReleaseAction(IProjectsRepository projects, long? build, string postfix )
		{
			_projects = projects;
			_build = build;
			_postfix = postfix;
		}

        public BulkSwitchToReleaseAction(IProjectsRepository projects, ComponentVersion version)
        {
            if (!version.IsDefined)
            {
                throw new InvalidOperationException("targer version is undefied");
            }
            if (version.IsSnapshot)
            {
                throw new InvalidOperationException("targer version is snapshot");
            }

            _projects = projects;
            _version = version;
        }

	    public void Execute()
		{
			var queue = new Queue<IProject>();
			var extractor = new ProjectDataExtractor();

			foreach (var project in _projects.AllProjects.Where(pn => pn.Version.IsSnapshot)) // first, deal with explicit version
			{
				project.Version = _version.IsDefined ? project.Version.SwitchSnapshotToRelease(_version) : project.Version.SwitchSnapshotToRelease(_build, _postfix);
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