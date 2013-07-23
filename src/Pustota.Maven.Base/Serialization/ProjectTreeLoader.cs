using System;
using System.Collections.Generic;
using System.IO;
using Pustota.Maven.Base.Data;

namespace Pustota.Maven.Base.Serialization
{
	public class ProjectTreeLoader
	{
		private readonly RepositoryEntryPoint _projectRepositoryPath;
		private readonly IProjectSerializer _serializer;
		private readonly IFileSystemAccess _fileIO;

		public ProjectTreeLoader(
			RepositoryEntryPoint projectRepositoryPath, 
			IProjectSerializer serializer,
			IFileSystemAccess fileIo)
		{
			_projectRepositoryPath = projectRepositoryPath;
			_serializer = serializer;
			_fileIO = fileIo;
		}

		public IEnumerable<ProjectContainer> LoadProjects()
		{
			if (_fileIO.IsDirectoryExist(_projectRepositoryPath.EntryPath))
			{
				return ScanFolder(_projectRepositoryPath.EntryPath);
			}
			if (_fileIO.IsFileExist(_projectRepositoryPath.EntryPath))
			{
				return ScanProject(_projectRepositoryPath.EntryPath);
			}
			return new ProjectContainer[] { };
		}

		private IEnumerable<ProjectContainer> ScanProject(string projectFilePath)
		{
			ProjectContainer project = LoadProjectFile(projectFilePath);
			yield return project;
			string projectFolder = _fileIO.GetDirectoryName(projectFilePath);
			foreach (var module in project.Modules)
			{
				string modulePath = _fileIO.Combine(projectFolder, module.Path, "pom.xml");
				if (_fileIO.IsFileExist(modulePath))
				{
					var subModules = ScanProject(modulePath);
					foreach (var subModule in subModules)
					{
						yield return subModule;
					}
				}
			}
		}

		private IEnumerable<ProjectContainer> ScanFolder(string folderPath)
		{
			string pomFileName = _fileIO.Combine(folderPath, "pom.xml");
			if (_fileIO.IsFileExist(pomFileName))
			{
				yield return LoadProjectFile(pomFileName);
			}

			foreach (var subfolder in _fileIO.EnumerateDirectories(folderPath))
			{
				string fullSubfolderPath = _fileIO.Combine(folderPath, subfolder);		
				foreach (var project in ScanFolder(fullSubfolderPath))
				{
					yield return project;
				}
			}
		}

		public ProjectContainer LoadProjectFile(string projectFilePath)
		{
			string content = _fileIO.ReadAllText(projectFilePath);
			return new ProjectContainer(projectFilePath,
				_serializer.Deserialize(content));
		}
	}
}