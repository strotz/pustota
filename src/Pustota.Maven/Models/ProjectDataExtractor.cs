using System;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Models
{
	internal class ProjectDataExtractor
	{
		private readonly IFileSystemAccess _system;

		internal ProjectDataExtractor(IFileSystemAccess system)
		{
			_system = system;
		}

		public IResolvedProjectData Extract(IProject project)
		{
			if (project == null)
				throw new ArgumentNullException("project");

			var data = new ResolvedProjectData();

			if (!string.IsNullOrEmpty(project.GroupId))
			{
				data.GroupId = project.GroupId;
			}
			else
			{
				if (project.Parent != null && !string.IsNullOrEmpty(project.Parent.GroupId))
				{
					data.GroupId = project.Parent.GroupId;
				}
			}

			if (project.ReferenceOperations().HasSpecificVersion)
			{
				data.Version = project.Version;
				data.IsSnapshot = project.ReferenceOperations().IsSnapshot;
			}
			else
			{
				if (project.Parent != null && project.Parent.ReferenceOperations().HasSpecificVersion)
				{
					data.Version = project.Parent.Version; // inherit from parent reference 
					data.IsSnapshot = project.Parent.ReferenceOperations().IsSnapshot;
				}
			}

			string parentPath = (project.Parent != null && !string.IsNullOrEmpty(project.Parent.RelativePath)) ?
				project.Parent.RelativePath : "../pom.xml";

			data.RelativeParentPath = parentPath;

			return data;
		}
	}
}