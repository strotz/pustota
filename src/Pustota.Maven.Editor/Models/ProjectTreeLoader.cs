using System.Collections.Generic;
using System.IO;

namespace Pustota.Maven.Editor.Models
{
	internal class ProjectTreeLoader
	{
		private readonly IProjectLoader _loader;

		private readonly string _rootPath;
		private readonly bool _fileBasedRepo;

		internal IList<IProject> AllProjects { get; private set; }
		internal IList<ProjectNode> AllProjectNodes { get; private set; }

		public const string ProjectFilePattern = "pom.xml";

		internal ProjectTreeLoader(string fileOrFolderName, bool fileBasedRepo)
		{
			_rootPath = Path.GetFullPath(fileOrFolderName);
			_fileBasedRepo = fileBasedRepo;

			_loader = new ProjectLoader(); // REVIEW: DI??? 
			
			AllProjects = new List<IProject>();
			AllProjectNodes = new List<ProjectNode>();
		}

		internal void LoadProjects()
		{
			if (_fileBasedRepo)
			{
				Queue<ProjectNode> queue = new Queue<ProjectNode>();

				var rootNode = AddProject(_rootPath);
				queue.Enqueue(rootNode);

				while (queue.Count != 0)
				{
					var projectNode = queue.Dequeue();

					if (projectNode.BaseDir == null) // REVIEW: why it is here?
						continue;

					foreach (var modulePath in projectNode.ModulePathList)
					{
						if (File.Exists(modulePath))
						{
							var subProjectNode = AddProject(modulePath);
							queue.Enqueue(subProjectNode);
						}
						// REVIEW: add validation? 
					}
				}
			}
			else
			{
				string[] files = Directory.GetFiles(_rootPath, ProjectFilePattern, SearchOption.AllDirectories);
				foreach (string fileName in files)
				{
					AddProject(fileName);
				}
			}
		}

		private ProjectNode AddProject(string path)
		{
			var project = _loader.LoadProject(path);
			var node = new ProjectNode(path, project);

			AllProjects.Add(project);
			AllProjectNodes.Add(node);

			return node;
		}
	}
}