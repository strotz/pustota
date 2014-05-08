using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pustota.Maven.Editor.Externals;
using Pustota.Maven.Editor.Validations;

namespace Pustota.Maven.Editor.Models
{
	internal class SolutionManagement
	{
		internal ISolution OpenSolution(string fileOrFolderName)
		{
			return new Solution(fileOrFolderName);
		}
	}

	internal interface ISolution // REVIEW: has all
	{
		string BaseDir { get; }

		// string FullPath { get; }

		IProjectsRepository ProjectsRepository { get; }

		ProjectsValidations Validations { get; } // REVIEW: encapsulate
		ExternalModulesRepository ExternalModules { get; } // REVIEW: encapsulate

		void Reload(); // REVIEW: delete it

		IEnumerable<ValidationError> Validate();

		bool Changed { get; }
	}

	internal class Solution : ISolution
	{
		private readonly string _fileOrFolderName;
		private readonly bool _fileBasedRepo;

		public string BaseDir { get; private set; }

		public IProjectsRepository ProjectsRepository { get; private set; }
		public ProjectsValidations Validations { get; private set; }
		public ExternalModulesRepository ExternalModules { get; private set; }

		// public string FullPath { get; private set; }

		public Solution(string fileOrFolderName)
		{
			_fileOrFolderName = fileOrFolderName;

			if (File.Exists(fileOrFolderName))
			{
				_fileBasedRepo = true;
			}
			else if (Directory.Exists(fileOrFolderName))
			{
				_fileBasedRepo = false;
			}
			else
			{
				throw new FileNotFoundException(fileOrFolderName);
			}
			var fullPath = Path.GetFullPath(fileOrFolderName);
			BaseDir = _fileBasedRepo ? Path.GetDirectoryName(fullPath) : fullPath;

			Load();
		}

		public void Reload()
		{
			Load();
		}

		public IEnumerable<ValidationError> Validate()
		{
			Validations.Validate();
			return Validations.ValidationErrors;
		}

		private void Load()
		{
			var treeLoader = new ProjectTreeLoader(_fileOrFolderName, _fileBasedRepo);
			treeLoader.LoadProjects();

			ProjectsRepository = new ProjectsRepository(treeLoader);

			ExternalModules = new ExternalModulesRepository(BaseDir); // REVIEW: BaseDir should be solution 
			Validations = new ProjectsValidations(ProjectsRepository, ExternalModules);
		}

		public bool Changed
		{
			// _ignoredValidations.Changed
			// _externalModules.Changed
			get { return ProjectsRepository.Changed; }
		}

	}
}
