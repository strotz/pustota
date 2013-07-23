using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pustota.Maven.Base.Data;
using Pustota.Maven.Base.Serialization;

namespace Pustota.Maven.Base
{
	public class Work
	{
		private readonly RepositoryEntryPoint _entryPoint;
		
		private readonly IFileSystemAccess _fileIo;

		private List<ProjectContainer> _projects;

		public Work(string topFolder)
		{
			_fileIo = new FileSystemAccess();
			_entryPoint = new RepositoryEntryPoint(topFolder, _fileIo);
		}

		public IEnumerable<IProject> Projects
		{
			get { return _projects.Select(pc => pc.Project); }
		}

		public void LoadProjects()
		{
			var serializer = new ProjectSerializer();
			var loader = new ProjectTreeLoader(_entryPoint, serializer, _fileIo);
			_projects = loader.LoadProjects().ToList();

		}
	}
}
