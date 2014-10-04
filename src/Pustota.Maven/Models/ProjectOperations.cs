using System.Collections.Generic;
using System.Linq;

namespace Pustota.Maven.Models
{
	internal class ProjectOperations : IProjectOperations
	{
		private readonly IProject _project;

		internal ProjectOperations(IProject project)
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
				return _project.Dependencies
					.Concat(_project.DependencyManagement)
					.Concat(_project.Profiles.SelectMany(p => p.Dependencies))
					.Concat(_project.Profiles.SelectMany(p => p.DependencyManagement));
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

		// my parent reference is equal to project reference 
		public bool HasProjectAsParent(IProjectReference projectReference, bool strictVersion)
		{
			var parentReference = _project.Parent;

			return
				parentReference != null &&
				parentReference.ReferenceOperations().ReferenceEqualTo(projectReference, strictVersion);
		}

		private bool HasDependencyOn(IProjectReference projectReference, bool strictVersion)
		{
			return AllDependencies.Any(d => d.ReferenceOperations().ReferenceEqualTo(projectReference, strictVersion));
		}

		private bool UsesPlugin(IProjectReference projectReference, bool strictVersion)
		{
			return AllPlugins.Any(d => d.ReferenceOperations().ReferenceEqualTo(projectReference, strictVersion));
		}

		// REVIEW: need review. switch to notify changed schema
		public void PropagateVersionToUsages(IProjectReference projectReference)
		{
			bool usageUpdated = false;

			if (HasProjectAsParent(projectReference, false))
			{
				if (_project.Parent.Version != projectReference.Version)
				{
					_project.Parent.Version = projectReference.Version;
					usageUpdated = true;
				}
			}

			foreach (var dependency in AllDependencies.Where(d => d.ReferenceOperations().ReferenceEqualTo(projectReference, false)))
			{
				if (dependency.Version != projectReference.Version)
				{
					dependency.Version = projectReference.Version;
					usageUpdated = true;
				}
			}

			foreach (var plugin in AllPlugins.Where(d => d.ReferenceOperations().ReferenceEqualTo(projectReference, false)))
			{
				if (plugin.Version.IsDefined && plugin.Version != projectReference.Version)
				{
					plugin.Version = projectReference.Version;
					usageUpdated = true;
				}
			}

			// TODO: Changed = usageUpdated;
		}

		public bool UsesProjectAs(IProjectReference projectReference, SearchOptions creteria)
		{
			if (creteria.LookForParents && HasProjectAsParent(projectReference, creteria.StrictVersion))
			{
				return true;
			}

			if (creteria.LookForDependent && HasDependencyOn(projectReference, creteria.StrictVersion))
			{
				return true;
			}

			if (creteria.LookForPlugin && UsesPlugin(projectReference, creteria.StrictVersion))
			{
				return true;
			}

			return false;
		}
	}
}