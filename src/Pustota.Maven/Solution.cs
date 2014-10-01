using System;
using System.IO;
using Pustota.Maven.Externals;
using Pustota.Maven.Serialization;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven
{
	// TODO: support multiple repositories within solution
	internal sealed class Solution :
		ExecutionContext,
		ISolution
	{
		private readonly IFileSystemAccess _fileIo;
		private readonly IProjectTreeLoader _loader;
		private readonly IExternalModulesLoader _externalModulesLoader;

		public string BaseDir { get; private set; }

		//public ProjectsValidations Validations { get; private set; }
		//public ExternalModulesRepository ExternalModules { get; private set; }

		internal Solution(
			IFileSystemAccess fileIo, 
			IProjectTreeLoader loader, 
			IExternalModulesLoader externalModulesLoader) : base(new PathCalculator(fileIo))
		{
			_fileIo = fileIo;
			_loader = loader;
			_externalModulesLoader = externalModulesLoader;
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
				foreach (var project in _loader.ScanForProjects(BaseDir))
				{
					Add(project);
				}
			}
			else
			{
				foreach (var project in _loader.LoadProjectTree(filePath))
				{
					Add(project);
				}
			}

			foreach (var externalModule in _externalModulesLoader.Load(BaseDir))
			{
				Add(externalModule);				
			}
		}

//		private void Load()
//		{
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
			_loader.SaveProjects(Tree);
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
