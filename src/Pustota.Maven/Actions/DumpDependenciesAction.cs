using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Actions
{
	internal class ProjectInheritanceFolder
	{
		private readonly IProjectsRepository _projects;

		internal ProjectInheritanceFolder(IProjectsRepository projects)
		{
			_projects = projects;
		}

		// TODO: it does not download or use m2 cache for projects
		public IEnumerable<IProject> BuildInheritanceChain(IProjectReference reference)
		{
			IProject project;
			if (!_projects.TryGetProject(reference, out project, true))
			{
				throw new InvalidOperationException("Project not found");
			}

			yield return project;
		}

		public IProject FoldProject(IEnumerable<IProject> inheritanceChain)
		{
			throw new NotImplementedException();
		}
	}

	public class DumpDependenciesAction
	{
		private readonly IProjectsRepository _projects;

		public DumpDependenciesAction(IProjectsRepository projects)
		{
			_projects = projects;
		}

//- a project dependency on another module in the build
//- a plugin declaration where the plugin is another modules in the build
//- a plugin dependency on another module in the build
//- a build extension declaration on another module in the build
//- the order declared in the <modules> element (if no other rule applies)

		public IEnumerable<string> Execute()
		{
			return _projects.AllProjects.Select(project => project.ToString());
		}
	}
}