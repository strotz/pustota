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
		private readonly IActionLog _log;
		private readonly IFileSystemAccess _fileSystem;
		private readonly IPathCalculator _path;

		public const string ProjectFilePattern = "pom.xml";

		internal ProjectTreeLoader(IFileSystemAccess fileSystem, IProjectReader projectReader, IProjectWriter projectWriter, IPathCalculator path, IActionLog log)
		{
			_path = path;
			_fileSystem = fileSystem;
			_projectReader = projectReader;
			_projectWriter = projectWriter;
			_log = log;
		}

		public IEnumerable<IProjectTreeItem> LoadProjectTree(string fileName)
		{
			if (!_fileSystem.IsFileExist(fileName))
			{
				throw new FileNotFoundException("Entry to project tree not found", fileName);
			}

			var fullPath = new FullPath(_fileSystem.GetFullPath(fileName));
			return ScanProject(fullPath);
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

		private IEnumerable<ProjectTreeElement> ScanProject(FullPath projectFullPath)
		{
			var treeState = new LoadTreeState();

			Queue<ProjectTreeElement> queue = new Queue<ProjectTreeElement>();

			var rootNode = AddProject(treeState, projectFullPath);
			queue.Enqueue(rootNode);

			while (queue.Count != 0)
			{
				var projectContainer = queue.Dequeue();
				_log.Info("Parsing project {0}", projectContainer.Path.Value);
				var modules = projectContainer.Project.Operations().AllModules;

				foreach (IModule module in modules)
				{
					FullPath modulePath;
					if (_path.TryResolveModulePath(projectContainer.Path, module.Path, out modulePath))
					{
						var subProjectNode = AddProject(treeState, modulePath);
						queue.Enqueue(subProjectNode);
					}
					else
					{
						_log.WriteMessage("Project: {0}, module is missing at {1}", projectContainer.Path, module.Path);	
					}
				}
			}

			return treeState.ScannedProjects;
		}

		private ProjectTreeElement AddProject(LoadTreeState treeState, FullPath fullPath)
		{
			var project = _projectReader.ReadProject(fullPath);
			var projectContainer = new ProjectTreeElement(fullPath, project);
			treeState.ScannedProjects.Add(projectContainer);
			return projectContainer;
		}
	}
}