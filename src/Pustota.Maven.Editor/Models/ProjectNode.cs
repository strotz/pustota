using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pustota.Maven.Editor.Validations;
using Pustota.Maven.Models;

namespace Pustota.Maven.Editor.Models
{
	internal class ProjectNode : ResolvedProjectData
	{
		public const string ProjectFilePattern = "pom.xml";

		private readonly List<string> _modulesPathList;
		private string _parentPath;

		internal ProjectNode(string fullPath, IProject project) :
			base(project)
		{
			FullPath = Path.GetFullPath(fullPath);
			BaseDir = Path.GetDirectoryName(FullPath); // REVIEW: DI?

			_modulesPathList = project
				.AllModules
				.Select(module => GetModulePath(BaseDir, module.Path))
				.ToList();

			string parentPath = (project.Parent != null && !string.IsNullOrEmpty(project.Parent.RelativePath)) ?
				project.Parent.RelativePath : "../pom.xml";

			_parentPath = PathOperations.Normalize(parentPath);
		}

		public bool Changed
		{
			get { return Project.Changed; }
			set { Project.Changed = value; }
		}

		private static string GetModulePath(string baseDir, string moduleName)
		{
			return Path.Combine(baseDir, moduleName, ProjectFilePattern);
		}


		public override string ToString()
		{
			return string.Format("POM: {0} {1}", ProjectKey, FullPath);
		}

		internal string BaseDir { get; private set; }
		internal string FullPath { get; private set; }

		internal IEnumerable<string> ModulePathList { get { return _modulesPathList; } }

		public bool IsSnapshot
		{
			get
			{
				return Version.IsSnapshot();
			}
			set
			{
				if (IsSnapshot != value)
				{
					Version = value ? Version.ToSnapshot() : Version.FromSnapshot();
				}
			}
		}

		public bool IsVersionUnresolved
		{
			get { return string.IsNullOrEmpty(Version); } // TODO: to VersionOperations... also need class for Version
		}

		public string ParentPath
		{
			get { return _parentPath; }
		}

		public bool ShareGroupAndArtifactWith(IProjectReference another)
		{
			return this.ReferenceEqualTo(another, false);
		}

		public void IncrementVersionAndEnableSnapshot()
		{
			if (string.IsNullOrEmpty(Version)) // TODO: need refactoring
			{
				IsSnapshot = true; // version will be defaulted 
			}
			else
			{
				string version = VersionOperations.ResetVersion(Version);
				version = version.ToSnapshot();
				Version = VersionOperations.IncrementNumber(version, 2); // TODO: make it flexable
			}
		}



		// REVIEW: need review. switch to notify changed schema
		public void PropagateVersionToUsages(IProjectReference projectReference)
		{
			if (HasProjectAsParent(projectReference, false))
			{
				if (Project.Parent.Version != projectReference.Version)
				{
					Project.Parent.Version = projectReference.Version; 
					Changed = true;
				}
			}

			foreach (var dependency in Project.AllDependencies.Where(d => d.ReferenceEqualTo(projectReference, false)))
			{
				if (dependency.Version != projectReference.Version)
				{
					dependency.Version = projectReference.Version;
					Changed = true;
				}
			}

			foreach (var plugin in Project.AllPlugins.Where(d => d.ReferenceEqualTo(projectReference, false)))
			{
				if (plugin.HasSpecificVersion && plugin.Version != projectReference.Version)
				{
					plugin.Version = projectReference.Version;
					Changed = true;
				}
			}
		}

		public void SwitchToRelease(string postfix = null)
		{
			string version = VersionOperations.ResetVersion(Version);
			Version = VersionOperations.AddPostfix(version, postfix); 
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

		private bool HasProjectAsParent(IProjectReference projectReference, bool strictVersion)
		{
			var parentReference = Project.Parent;

			return
				parentReference != null &&
				parentReference.ReferenceEqualTo(projectReference, strictVersion);
		}

		private bool HasDependencyOn(IProjectReference projectReference, bool strictVersion)
		{
			return Project.AllDependencies.Any(d => d.ReferenceEqualTo(projectReference, strictVersion));
		}

		private bool UsesPlugin(IProjectReference projectReference, bool strictVersion)
		{
			return Project.AllPlugins.Any(d => d.ReferenceEqualTo(projectReference, strictVersion));
		}
	}
}