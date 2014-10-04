using System;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Models
{
	internal class ProjectDataExtractor
	{
		public IProjectReference Extract(IProject project)
		{
			if (project == null)
				throw new ArgumentNullException("project");

			var data = new ProjectReference
			{
				ArtifactId = project.ArtifactId
			};

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

			if (project.Version.IsDefined)
			{
				data.Version = project.Version;
			}
			else
			{
				if (project.Parent != null && project.Parent.Version.IsDefined)
				{
					data.Version = project.Parent.Version; // inherit from parent reference 
				}
			}
			return data;
		}
	}
}