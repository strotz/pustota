using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven
{
	internal class ProjectTree : IProjectTree
	{
		private readonly IList<IProjectTreeItem> _projects;
		private readonly ProjectDataExtractor _extractor;

		protected ProjectTree()
		{
			_projects = new List<IProjectTreeItem>();
			_extractor = new ProjectDataExtractor();
		}

		protected IEnumerable<IProjectTreeItem> Tree { get { return _projects; } }

		public IEnumerable<IProjectReference> AllExtractedProjects
		{
			get { return _projects.Select(item => _extractor.Extract(item.Project)); } // TODO: cache
		}

		public IEnumerable<IProject> AllProjects { get { return _projects.Select(item => item.Project); } }

		// TODO: test it
		public bool TryGetProject(string groupId, string artifactId, string version, out IProject project, bool strictVersion = true)
		{
			var reference = new ProjectReference
			{
				GroupId = groupId,
				ArtifactId = artifactId,
				Version = version.ToVersion()
			};
			return TryGetProject(reference, out project, strictVersion);
		}

		public bool TryGetProject(IProjectReference reference, out IProject project, bool strictVersion = true)
		{
			var operation = reference.ReferenceOperations();

			project = AllProjects.
				SingleOrDefault(p =>
				{
					var r = _extractor.Extract(p);
					return operation.ReferenceEqualTo(r, strictVersion);
				});
			return project != null;
		}


		// TODO: test it
		public bool TryGetPathByProject(IProject project, out FullPath fullPath)
		{
			var item = _projects.SingleOrDefault(i => i.Project == project);
			if (item != null)
			{
				fullPath = item.Path;
				return true;
			}
			fullPath = FullPath.Undefined;
			return false;
		}

		// TODO: test it
		// TODO: to match path it use string compare, to simplify 
		public bool TryGetProjectByPath(FullPath fullPath, out IProject project)
		{
			try
			{
				var item = _projects.SingleOrDefault(i => i.Path.SameAs(fullPath));
				if (item != null)
				{
					project = item.Project;
					return true;
				}
			}
			catch (InvalidOperationException ex)
			{
				string message = "Problem requesting single key \"" + fullPath.Value + "\"";
				throw new InternalProjectTreeException(message, ex);
			}
			project = null;
			return false;
		}

		protected virtual void Reset()
		{
			_projects.Clear();
		}

		protected virtual void Add(IProjectTreeItem item)
		{
			_projects.Add(item);
		}
	}
}