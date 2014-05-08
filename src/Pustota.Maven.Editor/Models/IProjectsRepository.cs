using System;
using System.Collections.Generic;

namespace Pustota.Maven.Editor.Models
{
	internal interface IProjectsRepository
	{
		IList<ProjectNode> AllProjectNodes { get; }

		IEnumerable<ProjectNode> GetRootProjects();

		IEnumerable<ProjectNode> GetProjectModules(ProjectNode project);

		IList<IProject> AllProjects { get; set; }

		bool Changed { get; }

		// REVIEW: need refactoring
		void PropagateVersionToSubtree(ProjectNode original);
		void PropagateVersionToAllUsages(ProjectNode original);

		// REVIEW: remove and refactor usages
		IProject FindFirstProject(IProjectReference projectReference);

		void SaveChangedProjects();

		void LoadOneProject(string path);
		
		bool IsItUsed(IProjectReference projectReference);

		bool ContainsProject(IProjectReference projectReference, bool strictVersion = false);

		IEnumerable<ProjectNode> SelectProjectNodes(IProjectReference projectReference, bool strictVersion = false);
	}
}
