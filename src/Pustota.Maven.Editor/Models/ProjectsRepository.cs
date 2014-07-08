using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Editor.Models
{
	class ProjectsRepository : IProjectsRepository
	{
		public const string ProjectFilePattern = "pom.xml";


		private readonly IList<ProjectNode> _allProjectNodes;

		public IList<IProject> AllProjects { get; set; }

		public bool Changed
		{
			get { return AllProjectNodes.Any(node => node.Changed); }
		}

		public ProjectsRepository(ProjectTreeLoader treeLoader)
		{
			AllProjects = treeLoader.AllProjects;
			_allProjectNodes = treeLoader.AllProjectNodes;

			_loader = new ProjectLoader();
		}

		public IList<ProjectNode> AllProjectNodes
		{
			get { return _allProjectNodes; }
		}

		public IEnumerable<ProjectNode> GetRootProjects()
		{
			var pathesOfModules = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

			foreach (var node in _allProjectNodes)
			{
				if (node.BaseDir == null) // REVIEW: what is the use case?
				{
					continue;
				}

				foreach (var modulePath in node.ModulePathList)
				{
					pathesOfModules.Add(modulePath);
				}
			}
			return _allProjectNodes
				.Where(node => !pathesOfModules.Contains(node.FullPath));
		}

		public IEnumerable<ProjectNode> GetProjectModules(ProjectNode projectNode)
		{
			foreach (var modulePath in projectNode.ModulePathList)
			{
				var moduleNode = _allProjectNodes
					.SingleOrDefault(node => modulePath.Equals(node.FullPath, StringComparison.InvariantCultureIgnoreCase));
				if (moduleNode != null)
				{
					yield return moduleNode;
				}
			}
		}

		public bool IsItUsed(IProjectReference projectReference)
		{
			var creteria = new SearchOptions
			{
				LookForParents = true,
				LookForDependent = true,
				LookForPlugin = true,
				OnlyDirectUsages = true,
				StrictVersion = true
			};

			return AllProjectNodes.Any(node => node.UsesProjectAs(projectReference, creteria));
		}

		public bool ContainsProject(IProjectReference projectReference, bool strictVersion)
		{
			return AllProjectNodes.Any(p => p.ReferenceEqualTo(projectReference, strictVersion));
		}

		public IEnumerable<ProjectNode> SelectProjectNodes(IProjectReference projectReference, bool strictVersion = false)
		{
			return AllProjectNodes.Where(p => p.ReferenceEqualTo(projectReference, strictVersion));
		}


		public IProject FindFirstProject(IProjectReference projectReference)
		{
			return AllProjects.FirstOrDefault(p => p.ReferenceEqualTo(projectReference));
		}

		public void LoadOneProject(string path)
		{
			AllProjects.Add(_loader.LoadProject(path));
		}

		public void SaveChangedProjects()
		{
			foreach (Project prj in AllProjects.Where(prj => prj.Changed))
			{
				_loader.SaveProject(prj, prj.FullPath);
				prj.Changed = false;
			}

			// REVIEW: aggregate to solution

			//if (_externalModules.Changed)
			//	SaveExternalModules();
			//if (_ignoredValidations.Changed)
			//	SaveIgnoredValidations();
		}


		private IEnumerable<ProjectNode> FindProjectChildren(IProjectReference projectReference)
		{
			return AllProjectNodes.Where(node =>
				node.Project.Parent != null &&
				node.Project.Parent.ReferenceEqualTo(projectReference, false));
		}

		public void PropagateVersionToAllUsages(ProjectNode original)
		{
			string versionToPropagate = original.Version;

			foreach (var projectNode in AllProjectNodes)
			{
				projectNode.PropagateVersionToUsages(original);
			}

			foreach (var childPrj in FindProjectChildren(original))
			{
				if (childPrj.Project.Parent.HasSpecificVersion && childPrj.Project.Parent.Version != versionToPropagate)
				{
					childPrj.Project.Parent.Version = versionToPropagate;
					childPrj.Changed = true;
				}
				PropagateVersionToAllUsages(childPrj);
			}
		}

		public void PropagateVersionToSubtree(ProjectNode original) // REVIEW: refactor
		{
			PropagateVersionToAllUsages(original);

			string version = original.Project.Version;
			foreach (var moduleNode in GetProjectModules(original))
			{
				moduleNode.Version = version;
				PropagateVersionToSubtree(moduleNode);
			}
		}
	}
}
