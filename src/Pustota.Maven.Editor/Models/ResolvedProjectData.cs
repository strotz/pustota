using Pustota.Maven.Models;

namespace Pustota.Maven.Editor.Models
{
	internal class ResolvedProjectData : IProjectReference
	{
		internal Project Project { get; private set; }

		private string _resolvedGroupId;
		private string _resolvedVersion;

		internal ResolvedProjectData(Project project)
		{
			Project = project;

			if (!string.IsNullOrEmpty(project.GroupId))
			{
				_resolvedGroupId = project.GroupId;
			}
			else
			{
				if (project.Parent != null && !string.IsNullOrEmpty(Project.Parent.GroupId))
				{
					_resolvedGroupId = Project.Parent.GroupId;
				}
			}

			if (project.HasSpecificVersion)
			{
				_resolvedVersion = project.Version;
			}
			else
			{
				if (project.Parent != null && project.Parent.HasSpecificVersion)
				{
					_resolvedVersion = project.Parent.Version; // inherit from parent reference 
				}
			}
		}

		public string ArtifactId
		{
			get { return Project.ArtifactId; }
			set { Project.ArtifactId = value; }
		}

		public string GroupId
		{
			get { return _resolvedGroupId; }
			set
			{
				if (Project.GroupId != value)
				{
					Project.GroupId = value;
					Project.Changed = true;
				}
				_resolvedGroupId = value;
			}
		}

		public bool HasSpecificVersion
		{
			get { return Project.HasSpecificVersion; }
		}

		public string Version
		{
			get
			{
				return _resolvedVersion;
			}
			set
			{
				if (Project.Version != value)
				{
					Project.Version = value;
					Project.Changed = true;
				}
				_resolvedVersion = value;
			}
		}

		public string ProjectKey 
		{
			get { return Project.ProjectKey; } 
		}

	}
}