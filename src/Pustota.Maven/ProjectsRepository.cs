using System;
using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven
{
	class ProjectsRepository : IProjectsRepository
	{
		private readonly RepositoryEntryPoint _entryPoint;

		internal ProjectsRepository(string fileOrFolderName)
		{
			_entryPoint = new RepositoryEntryPoint(fileOrFolderName); // TODO: DI
		}

		public IEnumerable<IProject> AllProjects
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}