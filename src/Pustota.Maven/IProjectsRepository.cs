using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven
{
	public interface IProjectsRepository
	{
		IEnumerable<IProject> AllProjects { get; }

		bool TryGetProject(string groupId, string artifactId, string version, out IProject project, bool strictVersion = true);
		bool TryGetProject(IProjectReference reference, out IProject project, bool strictVersion = true);

		IEnumerable<IProjectReference> AllExtractedProjects { get; }
	}

	public interface IProjectTree : IProjectsRepository
	{
		bool TryGetPathByProject(IProject project, out FullPath fullPath);
		bool TryGetProjectByPath(FullPath fullParentPath, out IProject parent);
	}

		//	IEnumerable<ProjectNode> GetRootProjects();
		//	IEnumerable<ProjectNode> GetProjectModules(ProjectNode project);
		
		//	bool Changed { get; }

		//	void SaveChangedProjects();
		//	void LoadOneProject(string path);

		//	bool IsItUsed(IProjectReference projectReference);
		//	IEnumerable<ProjectNode> SelectProjectNodes(IProjectReference projectReference, bool strictVersion = false);

	public interface IExecutionContext : 
		IProjectTree
	{
		bool TryGetParentByPath(IProject project, out IProject parent);

		bool IsExternalModule(IProjectReference projectReference);
		IEnumerable<IProjectReference> AllAvailableProjectReferences { get; } // REVIEW: should it be Get with parameters?
	}
}
