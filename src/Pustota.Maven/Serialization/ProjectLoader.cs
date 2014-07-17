using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Pustota.Maven.Models;
using Pustota.Maven.System;

namespace Pustota.Maven.Serialization
{
	internal class ProjectLoader : IProjectLoader
	{
		private readonly IFileSystemAccess _fileSystem;
		private readonly IProjectSerializerWithUpdate _serializer;

		internal ProjectLoader(IFileSystemAccess fileSystem, IProjectSerializerWithUpdate serializer)
		{
			_fileSystem = fileSystem;
			_serializer = serializer;
		}

		public IProject ReadProject(string path)
		{
			string content = _fileSystem.ReadAllText(path);
			var project = _serializer.Deserialize(content);
			return project;
		}

		public void UpdateProject(IProject project, string path)
		{
			string content = _fileSystem.ReadAllText(path);
			string updated = _serializer.Serialize(project, content);
			_fileSystem.WriteAllText(path, updated);
		}
	}
}
