using System.Collections.Generic;
using System.Linq;

namespace Pustota.Maven.Models
{
	internal class AggregatedProject : IAggregatedProject
	{
		private readonly IProject _project;

		internal AggregatedProject(IProject project)
		{
			_project = project;
		}

		// REVIEW: also possible to do it base on activated profiles
		public IEnumerable<IModule> AllModules
		{
			get { return _project.Modules.Concat(_project.Profiles.SelectMany(p => p.Modules)); }
		}

		public IEnumerable<IDependency> AllDependencies
		{
			get
			{
				return _project.Dependencies.Concat(_project.Profiles.SelectMany(p => p.Dependencies));
			}
		}

		public IEnumerable<IProperty> AllProperties
		{
			get
			{
				return _project.Properties.Concat(_project.Profiles.SelectMany(p => p.Properties));
			}
		}

		public IEnumerable<IPlugin> AllPlugins
		{
			get
			{
				return _project.Plugins
					.Concat(_project.PluginManagement)
					.Concat(_project.Profiles.SelectMany(p => p.Plugins))
					.Concat(_project.Profiles.SelectMany(p => p.PluginManagement));
			}
		}
	}
}