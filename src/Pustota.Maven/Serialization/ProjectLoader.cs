using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Pustota.Maven.Models;
using Pustota.Maven.System;

namespace Pustota.Maven.Serialization
{

	// REVIEW: leave writer/reader part here, Serialize/Deserialize can go ProjectSerializer   
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
			// string fullPath = _fileSystem.GetFullPath(path);
			string content = _fileSystem.ReadAllText(path);
			var project = _serializer.Deserialize(content);
			// REVIEW: project.FullPath = fullPath;
			return project;
		}

		internal void SaveProjectDocument(XDocument document, string fileName)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Encoding = Encoding.ASCII,
				Indent = true,
				IndentChars = "\t"
			};

			string directoryName = _fileSystem.GetDirectoryName(fileName);
			if (!_fileSystem.IsDirectoryExist(directoryName))
			{
				_fileSystem.CreateDirectory(directoryName);
			}

			using (XmlWriter writer = XmlWriter.Create(fileName, settings))
			{
				document.WriteTo(writer);
			}
		}

		//internal string SaveMavenProject(MavenProjectDocument mavenProject)
		//{
		//	using (TextWriter writer = new UsAsciiStringWriter())
		//	{
		//		mavenProject.Document.Save(writer, mavenProject.EnableFormatting ? SaveOptions.None : SaveOptions.DisableFormatting);
		//		return writer.ToString();
		//	}
		//}


		public void SaveProject(IProject project, string path)
		{
			throw new NotImplementedException();

			//PomXmlDocument pom;

			//string fullPath = _fileSystem.GetFullPath(path);

			//// REVIEW: remove
			//// REVIEW: project.FullPath = fullPath;

			//if (_fileSystem.IsFileExist(fullPath))
			//{
			//	pom = new PomXmlDocument(fullPath);
			//	project.UpdatePomXml(pom);
			//}
			//else
			//{
			//	pom = project.GetPomXml();
			//}

			//pom.SaveTo(path);

			// TODO: make sure it is covered by caller project.Changed = false;
		}

		public void UpdateProject(IProject project, string path)
		{
			_serializer.Serialize(project, null);
		}
	}
}
