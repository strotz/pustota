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

		internal ProjectLoader(IFileSystemAccess fileSystem)
		{
			_fileSystem = fileSystem;
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

		internal XDocument LoadXmlDocument(string fileName)
		{
			// DefaultNamespaceName
			return XDocument.Load(fileName);
		}

		//internal string SaveMavenProject(MavenProjectDocument mavenProject)
		//{
		//	using (TextWriter writer = new UsAsciiStringWriter())
		//	{
		//		mavenProject.Document.Save(writer, mavenProject.EnableFormatting ? SaveOptions.None : SaveOptions.DisableFormatting);
		//		return writer.ToString();
		//	}
		//}


		public IProject LoadProject(string path)
		{
			//string fullPath = _fileSystem.GetFullPath(path);

			//XDocument document = LoadXmlDocument(fullPath);
			//// var pom = new PomXmlDocument(fullPath); // load file to document

			//var project = _dataFactory.CreateProject();
			//// REVIEW: project.FullPath = fullPath;
			//return project;

			throw new NotImplementedException();
		}

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
	}
}
