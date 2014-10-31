using Pustota.Maven.Models;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Serialization
{
	internal class ProjectLoader : IProjectLoader
	{
		private readonly IFileSystemAccess _fileSystem;
		private readonly IProjectSerializerWithUpdate _serializer;
		private readonly IActionLog _log;

		internal ProjectLoader(IFileSystemAccess fileSystem, IProjectSerializerWithUpdate serializer, IActionLog log)
		{
			_fileSystem = fileSystem;
			_serializer = serializer;
			_log = log;
		}

		public IProject ReadProject(string path)
		{
			_log.WriteMessage("Try to load project {0}", path);

			string content = _fileSystem.ReadAllText(path);
			var project = _serializer.Deserialize(content);
			return project;
		}

		public void UpdateProject(IProject project, string path)
		{
			_log.WriteMessage("Try to save project {0}", path);

			string content = _fileSystem.ReadAllText(path);
			string updated = _serializer.Serialize(project, content);
			_fileSystem.WriteAllText(path, updated);
		}
	}
}
