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
		private IProjectSerializer _projectSerializer;

		public Work(string topFolder)
		{
			_fileIo = new FileSystemAccess();
			_entryPoint = new RepositoryEntryPoint(topFolder, _fileIo);
			_projectSerializer = new ProjectSerializer();
		}

		public IEnumerable<IProject> Projects
		{
			get { return _projects.Select(pc => pc.Project); }
		}

		public void LoadProjects()
		{
			var loader = new ProjectTreeLoader(_entryPoint, _projectSerializer, _fileIo);
			_projects = loader.LoadProjects().ToList();

		}

		public void ForceSaveAll()
		{
			foreach (ProjectContainer container in _projects)
			{
				var content = _projectSerializer.Serialize((Project) container.Project);
				_fileIo.WriteAllText(container.Path, content);
			}
		}
	}
}
