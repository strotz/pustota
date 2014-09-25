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

		//	void SaveChangedProjects();
		//	void LoadOneProject(string path);

		//	bool IsItUsed(IProjectReference projectReference);
		//	IEnumerable<ProjectNode> SelectProjectNodes(IProjectReference projectReference, bool strictVersion = false);

	public interface IExecutionContext : 
		IProjectTree
	{
		bool TryGetParentByPath(IProject project, out IProject parent);
	}
}
