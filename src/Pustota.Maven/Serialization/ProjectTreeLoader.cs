using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pustota.Maven.Models;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Serialization
{
	internal class ProjectTreeLoader : IProjectTreeLoader
	{
		private class LoadTreeState
		{
			internal IList<ProjectTreeElement> ScannedProjects { get; private set; }
			internal LoadTreeState()
			{
				ScannedProjects = new List<ProjectTreeElement>();
			}
		}

		private readonly IProjectReader _projectReader;
		private readonly IProjectWriter _projectWriter;
		private readonly IFileSystemAccess _fileSystem;

		public const string ProjectFilePattern = "pom.xml";

		internal ProjectTreeLoader(IFileSystemAccess fileSystem, IProjectReader projectReader, IProjectWriter projectWriter)
		{
			_fileSystem = fileSystem;
			_projectReader = projectReader;
			_projectWriter = projectWriter;
		}

		public IEnumerable<IProjectTreeItem> LoadProjectTree(string fileName)
		{
			if (!_fileSystem.IsFileExist(fileName))
			{
				throw new FileNotFoundException("Entry to project tree not found", fileName);
			}

			return ScanProject(fileName);
		}

		public IEnumerable<IProjectTreeItem> ScanForProjects(string folderName)
		{
			if (!_fileSystem.IsDirectoryExist(folderName))
			{
				throw new FileNotFoundException("Project tree not found", folderName);
			}

			string[] files = _fileSystem.GetFiles(folderName, ProjectFilePattern, SearchOption.AllDirectories);
			return files.
				Select(fileName => new FullPath(_fileSystem.GetFullPath(fileName))).
				Select(fullPath => new ProjectTreeElement(fullPath, _projectReader.ReadProject(fullPath)));
		}

		public void SaveProjects(IEnumerable<IProjectTreeItem> projects)
		{
			foreach (var projectTreeElement in projects)
			{
				_projectWriter.UpdateProject(projectTreeElement.Project, projectTreeElement.Path);
			}
		}

		private IEnumerable<ProjectTreeElement> ScanProject(string fileName)
		{
			var treeState = new LoadTreeState();

			Queue<ProjectTreeElement> queue = new Queue<ProjectTreeElement>();

			var rootNode = AddProject(treeState, fileName);
			queue.Enqueue(rootNode);

			while (queue.Count != 0)
			{
				var projectContainer = queue.Dequeue();
				string baseDir = _fileSystem.GetDirectoryName(projectContainer.Path);
				var modules =
					projectContainer.Project.Operations().AllModules
						.Select(module => BuildAbsoluteModulePath(baseDir, module));

				foreach (var modulePath in modules)
				{
					if (_fileSystem.IsFileExist(modulePath))
					{
						var subProjectNode = AddProject(treeState, modulePath);
						queue.Enqueue(subProjectNode);
					}
					// REVIEW: add validation? 
				}
			}

			return treeState.ScannedProjects;
		}

		private ProjectTreeElement AddProject(LoadTreeState treeState, string path)
		{
			var project = _projectReader.ReadProject(path);
			var fullPath = new FullPath(_fileSystem.GetFullPath(path));
			var projectContainer = new ProjectTreeElement(fullPath, project);
			treeState.ScannedProjects.Add(projectContainer);
			return projectContainer;
		}

		private string BuildAbsoluteModulePath(string baseDir, IModule module)
		{
			return _fileSystem.Combine(baseDir, module.Path, ProjectFilePattern);
		}
	}
}