using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

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

		public IEnumerable<IProject> AllProjects { get { return _projects.Select(item => item.Project); } }

		// TODO: test it
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
			var item = _projects.SingleOrDefault(i => String.Equals(fullPath, i.Path, StringComparison.InvariantCultureIgnoreCase));
			if (item != null)
			{
				project = item.Project;
				return true;
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