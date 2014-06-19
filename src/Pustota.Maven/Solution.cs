using System;
using System.Collections.Generic;
using System.IO;
using Pustota.Maven.Serialization;
using Pustota.Maven.System;

namespace Pustota.Maven
{
	internal class Solution : ISolution
	{
		private readonly IFileSystemAccess _fileIo;

		// private IProjectSerializer _projectSerializer;

		public string BaseDir { get; private set; }

		public IProjectsRepository ProjectsRepository { get; private set; }
		//public ProjectsValidations Validations { get; private set; }
		//public ExternalModulesRepository ExternalModules { get; private set; }

		// public string FullPath { get; private set; }

		internal Solution()
		{
			_fileIo = new FileSystemAccess(); // TODO: DI
			//_projectSerializer = new ClassicProjectSerializer();
		}

		public void Open(string fileOrFolderName)
		{
			if (fileOrFolderName == null) throw new ArgumentNullException("fileOrFolderName");

			var fullPath = _fileIo.GetFullPath(fileOrFolderName);
			if (_fileIo.IsFileExist(fullPath))
			{
				BaseDir = _fileIo.GetDirectoryName(fullPath);
			}
			else if (_fileIo.IsDirectoryExist(fullPath))
			{
				BaseDir = fullPath;
			}
			else
			{
				throw new FileNotFoundException(fullPath);
			}

			ProjectsRepository = new ProjectsRepository(fullPath);

			throw new NotImplementedException();

			//Load();
		}

//		public void Reload()
//		{
//			Load();
//		}

//		public IEnumerable<ValidationError> Validate()
//		{
//			Validations.Validate();
//			return Validations.ValidationErrors;
//		}

//		private void Load()
//		{
//			var treeLoader = new ProjectTreeLoader(_fileOrFolderName, _fileBasedRepo);
//			treeLoader.LoadProjects();

//			ProjectsRepository = new ProjectsRepository(treeLoader);

//			ExternalModules = new ExternalModulesRepository(BaseDir); // REVIEW: BaseDir should be solution 
//			Validations = new ProjectsValidations(ProjectsRepository, ExternalModules);
//		}

//		public bool Changed
//		{
//			// _ignoredValidations.Changed
//			// _externalModules.Changed
//			get { return ProjectsRepository.Changed; }
//		}

//		public IEnumerable<IProject> Projects
//		{
//			get { return _projects.Select(pc => pc.Project); }
//		}

//		public void LoadProjects()
//		{
//			// var loader = new ProjectTreeLoader(_entryPoint, _projectSerializer, _fileIo);
//			// _projects = loader.LoadProjects().ToList();

//		}

//		public void ForceSaveAll()
//		{
//			foreach (ProjectContainer container in _projects)
//			{
////				var content = _projectSerializer.Serialize((Project) container.Project);
////				_fileIo.WriteAllText(container.Path, content);
//			}
//		}

	}
}
