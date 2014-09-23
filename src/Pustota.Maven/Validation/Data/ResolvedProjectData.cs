using Pustota.Maven.Models;

namespace Pustota.Maven.Validation.Data
{
	internal class ResolvedProjectData : IResolvedProjectData
	{
		public string GroupId { get; internal set; }
		public string Version { get; internal set; }
		public bool? IsSnapshot { get; internal set; }
	}

	// REVIEW: it just one piece
	internal class Loader
	{
		internal static ResolvedProjectData Resolve(IProject project)
		{
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

			return data;
		}
	}
}