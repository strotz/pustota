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




	}
}