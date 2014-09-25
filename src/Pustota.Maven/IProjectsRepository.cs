using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven
{
	public interface IProjectsRepository
	{
		IEnumerable<IProject> AllProjects { get; }

		bool TryGetProject(IProjectReference reference, out IProject project, bool strictVersion = true);
	}

	public interface IProjectTree : IProjectsRepository
	{
		// IEnumerable<IProjectTreeItem> Tree { get; }

		bool TryGetPathByProject(IProject project, out FullPath fullPath);
		bool TryGetProjectByPath(FullPath fullParentPath, out IProject parent);
	}

		//	IEnumerable<ProjectNode> GetRootProjects();
		//	IEnumerable<ProjectNode> GetProjectModules(ProjectNode project);

		
		//	bool Changed { get; }

		//	// REVIEW: need refactoring
		//	void PropagateVersionToSubtree(ProjectNode original);
		//	void PropagateVersionToAllUsages(ProjectNode original);

		//	// REVIEW: remove and refactor usages
		//	IProject FindFirstProject(IProjectReference projectReference);

		//	void SaveChangedProjects();

		//	void LoadOneProject(string path);

		//	bool IsItUsed(IProjectReference projectReference);

		//	bool ContainsProject(IProjectReference projectReference, bool strictVersion = false);

		//	IEnumerable<ProjectNode> SelectProjectNodes(IProjectReference projectReference, bool strictVersion = false);

	public interface IExecutionContext : 
		IProjectTree
	{
		IResolvedProjectData GetResolvedData(IProject project);

		bool TryGetParentByPath(IProject project, out IProject parent);
	}
}
