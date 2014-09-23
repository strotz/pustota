using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Actions
{
	public class DumpClassifiersAction
	{
		private readonly IProjectsRepository _projects;

		public DumpClassifiersAction(IProjectsRepository projects)
		{
			_projects = projects;
		}

		public IEnumerable<string> Execute()
		{
			var cache = new HashSet<string>();

			foreach (var classifier in _projects.AllProjects.SelectMany(p => p.Operations().AllDependencies).Where(d => !string.IsNullOrEmpty(d.Classifier) && d.Classifier.Contains("${")).Select(d => d.Classifier))
			{
				if (!cache.Contains(classifier))
				{
					cache.Add(classifier);
					yield return classifier;
				}
			}
		}
	}
}
