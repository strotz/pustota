using System;
using System.Collections.Generic;
using System.Linq;

namespace Pustota.Maven.Actions
{
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