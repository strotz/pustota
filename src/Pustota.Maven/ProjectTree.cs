using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven
{
	internal class ProjectTree : IProjectTree
	{
		protected IList<IProjectTreeItem> Projects { get; private set; } // REVIEW: hide it

		protected ProjectTree()
		{
			Projects = new List<IProjectTreeItem>();
		}

		public IEnumerable<IProject> AllProjects { get { return Projects.Select(item => item.Project); } }

		// TODO: test it
		public bool TryGetProject(IProjectReference reference, out IProject project, bool strictVersion = true)
		{
			var operation = reference.ReferenceOperations();
			project = AllProjects.SingleOrDefault(p => operation.ReferenceEqualTo(p, strictVersion));
			return project != null;
		}

		// public IEnumerable<IProjectTreeItem> Tree { get { return Projects; } }

		// TODO: test it
		public bool TryGetPathByProject(IProject project, out FullPath fullPath)
		{
			var item = Projects.SingleOrDefault(i => i.Project == project);
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
			var item = Projects.SingleOrDefault(i => String.Equals(fullPath, i.Path, StringComparison.InvariantCultureIgnoreCase));
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
			Projects.Clear();
		}

		protected virtual void Add(IProjectTreeItem item)
		{
			Projects.Add(item);
		}
	}
}