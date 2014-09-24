using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven
{
	internal class ProjectTree : IProjectTree
	{
		protected IList<IProjectTreeItem> Projects; // REVIEW: hide it

		protected ProjectTree()
		{
			Projects = new List<IProjectTreeItem>();
		}

		public IEnumerable<IProject> AllProjects { get { return Projects.Select(item => item.Project); } }
		// public IEnumerable<IProjectTreeItem> Tree { get { return Projects; } }

		// TODO: match object reference, but should it be project references? 
		public bool TryGetPathByProject(IProject project, out FullPath fullPath)
		{
			var item = Projects.SingleOrDefault(i => i.Project == project);
			if (item != null)
			{
				fullPath = item.Path;
				return true;
			}
			fullPath = null;
			return false;
		}

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
	}

	internal class ExecutionContext : 
		ProjectTree,
		IExecutionContext
	{
		private readonly IDictionary<IProject, IResolvedProjectData> _resolved;

		protected ExecutionContext()
		{
			_resolved = new Dictionary<IProject, IResolvedProjectData>();
		}

		// TODO: it is implementation of lazy project data resolution - probably can switch to explicit model
		public IResolvedProjectData GetResolvedData(IProject project)
		{
			//IResolvedProjectData resolvedData;
			//if (!_resolved.TryGetValue(project, out resolvedData))
			//{
			//	resolvedData = project.Operations().ResolveMoreData();
			//	_resolved[project] = resolvedData;
			//}
			//return resolvedData;
			throw new NotImplementedException();
		}

		public bool TryGetParentByPath(IProject project, out IProject parent)
		{
			//string currentProjectPath;
			//if (!TryGetPathByProject(project, out currentProjectPath))
			//{
			//	parent = null;
			//	return false;
			//}

			//string resolvedParentPath = GetResolvedData(project).ParentPath;
			//string fullParentPath = _system.Normalize(_system)
			//return TryGetProjectByPath(fullParentPath, out parent);
			throw new NotImplementedException();
		}

		protected void CleanContext()
		{
			throw new NotImplementedException();
		}


	}

	// TODO: support multiple repositories within solution
	internal sealed class Solution :
		ExecutionContext,
		ISolution
	{
		private readonly IFileSystemAccess _fileIo;
		private readonly IProjectTreeLoader _loader;

		public string BaseDir { get; private set; }

		//public ProjectsValidations Validations { get; private set; }
		//public ExternalModulesRepository ExternalModules { get; private set; }

		internal Solution(IFileSystemAccess fileIo, IProjectTreeLoader loader)
		{
			_fileIo = fileIo;
			_loader = loader;
		}

		// REVIEW: loadDisconnectedProjects need to be rewired
		internal void Open(string fileOrFolderName, bool loadDisconnectedProjects)
		{
			if (fileOrFolderName == null) throw new ArgumentNullException("fileOrFolderName");

			string fullPath = _fileIo.GetFullPath(fileOrFolderName);
			string filePath;

			if (_fileIo.IsFileExist(fullPath))
			{
				BaseDir = _fileIo.GetDirectoryName(fullPath);
				filePath = fullPath;
			}
			else if (_fileIo.IsDirectoryExist(fullPath))
			{
				BaseDir = fullPath;
				filePath = _fileIo.Combine(fullPath, ProjectTreeLoader.ProjectFilePattern);
			}
			else
			{
				throw new FileNotFoundException("Solution entry point is missing", fullPath);
			}

			if (loadDisconnectedProjects)
			{
				Projects = _loader.ScanForProjects(BaseDir).ToList();
			}
			else
			{
				Projects = _loader.LoadProjectTree(filePath).ToList();
			}
		}

//		private void Load()
//		{
////			ExternalModules = new ExternalModulesRepository(BaseDir); // REVIEW: BaseDir should be solution 
////			Validations = new ProjectsValidations(ProjectsRepository, ExternalModules);
//		}

//		public bool Changed
//		{
//			// _ignoredValidations.Changed
//			// _externalModules.Changed
//			get { return ProjectsRepository.Changed; }
//		}

		public void ForceSaveAll()
		{
			_loader.SaveProjects(Projects);
		}

		//public IEnumerable<ProjectNode> GetRootProjects()
		//{
		//	var pathesOfModules = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

		//	foreach (var node in _allProjectNodes)
		//	{
		//		if (node.BaseDir == null) // REVIEW: what is the use case?
		//		{
		//			continue;
		//		}

		//		foreach (var modulePath in node.ModulePathList)
		//		{
		//			pathesOfModules.Add(modulePath);
		//		}
		//	}
		//	return _allProjectNodes
		//		.Where(node => !pathesOfModules.Contains(node.FullPath));
		//}

		//public IEnumerable<ProjectNode> GetProjectModules(ProjectNode projectNode)
		//{
		//	foreach (var modulePath in projectNode.ModulePathList)
		//	{
		//		var moduleNode = _allProjectNodes
		//			.SingleOrDefault(node => modulePath.Equals(node.FullPath, StringComparison.InvariantCultureIgnoreCase));
		//		if (moduleNode != null)
		//		{
		//			yield return moduleNode;
		//		}
		//	}
		//}

		//public bool IsItUsed(IProjectReference projectReference)
		//{
		//	var creteria = new SearchOptions
		//	{
		//		LookForParents = true,
		//		LookForDependent = true,
		//		LookForPlugin = true,
		//		OnlyDirectUsages = true,
		//		StrictVersion = true
		//	};

		//	return AllProjectNodes.Any(node => node.UsesProjectAs(projectReference, creteria));
		//}

		//public bool ContainsProject(IProjectReference projectReference, bool strictVersion)
		//{
		//	return AllProjectNodes.Any(p => p.ReferenceEqualTo(projectReference, strictVersion));
		//}

		//public IEnumerable<ProjectNode> SelectProjectNodes(IProjectReference projectReference, bool strictVersion = false)
		//{
		//	return AllProjectNodes.Where(p => p.ReferenceEqualTo(projectReference, strictVersion));
		//}

		//public IProject FindFirstProject(IProjectReference projectReference)
		//{
		//	return AllProjects.FirstOrDefault(p => p.ReferenceEqualTo(projectReference));
		//}

		//public void SaveChangedProjects()
		//{
		//	foreach (Project prj in AllProjects.Where(prj => prj.Changed))
		//	{
		//		_loader.SaveProject(prj, prj.FullPath);
		//		prj.Changed = false;
		//	}

		//	// REVIEW: aggregate to solution

		//	//if (_externalModules.Changed)
		//	//	SaveExternalModules();
		//	//if (_ignoredValidations.Changed)
		//	//	SaveIgnoredValidations();
		//}
	}
}
