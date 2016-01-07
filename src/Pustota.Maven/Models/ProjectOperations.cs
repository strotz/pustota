using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

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

		public IEnumerable<IProjectReference> AllReferences
		{
			get
			{
				if (_project.Parent != null)
					yield return _project.Parent;

				foreach (var dependency in AllDependencies)
				{
					yield return dependency;
				}
				foreach (var plugin in AllPlugins)
				{
					yield return plugin;
				}
			}
		}

		public ComponentVersion ActualVersion
		{
			get
			{
				if (_project.Version.IsDefined)
				{
					return _project.Version;
				}

				if (_project.Parent != null && _project.Parent.Version.IsDefined)
				{
					return _project.Parent.Version;
				}

				return ComponentVersion.Undefined;
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
			var newVersion = projectReference.Version;

			if (HasProjectAsParent(projectReference, false))
			{
				if (_project.Parent.Version != newVersion)
				{
					_project.Parent.Version = newVersion;
					usageUpdated = true;
				}
			}

			foreach (var dependency in AllDependencies.Where(d => d.ReferenceOperations().ReferenceEqualTo(projectReference, false)))
			{
				if (dependency.Version != newVersion)
				{
					dependency.Version = newVersion;
					usageUpdated = true;
				}
			}

			foreach (var plugin in AllPlugins.Where(d => d.ReferenceOperations().ReferenceEqualTo(projectReference, false)))
			{
				if (plugin.Version.IsDefined && plugin.Version != newVersion)
				{
					plugin.Version = newVersion;
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