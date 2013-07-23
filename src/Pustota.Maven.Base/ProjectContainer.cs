using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pustota.Maven.Base.Data;

namespace Pustota.Maven.Base
{
	public class ProjectContainer
	{
		private string _projectFilePath;
		private readonly IProject _project;

		public ProjectContainer(string projectFilePath, IProject project)
		{
			if (project == null)
				throw new ArgumentNullException("project");

			_projectFilePath = projectFilePath;
			_project = project;
		}

		public IEnumerable<Module> Modules
		{
			get
			{
				foreach (Module module in _project.Modules)
				{
					yield return module;
				}
			}
		}

		public IProject Project
		{
			get { return _project; }
		}
	}
}
