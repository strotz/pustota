using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pustota.Maven.Models;
using Pustota.Maven.System;

namespace Pustota.Maven.Serialization
{
	internal class ProjectTreeLoader : IProjectTreeLoader
	{
		private class ProjectContainer
		{
			private readonly IProject _project;
			private readonly string _baseDir;

			public ProjectContainer(string baseDir, IProject project)
			{
				_baseDir = baseDir;
				_project = project;
			}

			internal IProject Project
			{
				get { return _project; }
			}

			internal string BaseDir
			{
				get { return _baseDir; }
			}
		}

		private class LoadTreeState
		{
			internal IList<ProjectContainer> ScannedProjects { get; private set; }
			internal LoadTreeState()
			{
				ScannedProjects = new List<ProjectContainer>();
			}
		}

		private readonly IProjectReader _reader;
		private readonly IFileSystemAccess _fileSystem;

		public const string ProjectFilePattern = "pom.xml";

		internal ProjectTreeLoader(IFileSystemAccess fileSystem, IProjectReader reader)
		{
			_fileSystem = fileSystem;
			_reader = reader;
		}

		public IEnumerable<IProject> LoadProjectTree(string fileOrFolderName)
		{
			if (_fileSystem.IsDirectoryExist(fileOrFolderName))
			{
				return ScanFolder(fileOrFolderName);
			}
			if (_fileSystem.IsFileExist(fileOrFolderName))
			{
				return ScanProject(fileOrFolderName);
			}
			return new IProject[] { };
		}

		private IEnumerable<IProject> ScanFolder(string folderName)
		{
			string[] files = _fileSystem.GetFiles(folderName, ProjectFilePattern, SearchOption.AllDirectories);
			return files.Select(fileName => _reader.ReadProject(fileName));
		}

		private IEnumerable<IProject> ScanProject(string fileName)
		{
			var treeState = new LoadTreeState();

			Queue<ProjectContainer> queue = new Queue<ProjectContainer>();

			var rootNode = AddProject(treeState, fileName);
			queue.Enqueue(rootNode);

			while (queue.Count != 0)
			{
				var projectContainer = queue.Dequeue();

				string baseDir = projectContainer.BaseDir;
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

			return treeState.ScannedProjects.Select(item => item.Project);
		}

		private ProjectContainer AddProject(LoadTreeState treeState, string path)
		{
			var project = _reader.ReadProject(path);
			string baseDir = _fileSystem.GetDirectoryName(path);
			var projectContainer = new ProjectContainer(baseDir, project);
			treeState.ScannedProjects.Add(projectContainer);
			return projectContainer;
		}

		private string BuildAbsoluteModulePath(string baseDir, IModule module)
		{
			return _fileSystem.Combine(baseDir, module.Path, ProjectFilePattern);
		}
	}
}