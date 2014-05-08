using System.IO;
using Pustota.Maven.Editor.PomXml;

namespace Pustota.Maven.Editor.Models
{
	internal class ProjectLoader : IProjectLoader
	{
		private readonly DataFactory _dataFactory;

		internal ProjectLoader()
		{
			_dataFactory = new DataFactory(); // TODO: DI
		}

		public Project LoadProject(string path)
		{
			string fullPath = Path.GetFullPath(path);
			var pom = new PomXmlDocument(fullPath); // load file to document

			var project = _dataFactory.CreateProject();

			project.FullPath = fullPath;
			project.LoadDataFromXml(pom);

			return project;
		}

		public void SaveProject(Project project, string path)
		{
			PomXmlDocument pom;

			string fullPath = Path.GetFullPath(path);

			// REVIEW: remove
			project.FullPath = fullPath;

			if (File.Exists(fullPath))
			{
				pom = new PomXmlDocument(fullPath);
				project.UpdatePomXml(pom);
			}
			else
			{
				pom = project.GetPomXml();
			}

			pom.SaveTo(path);
			
			// TODO: was translation assembly save
			// if (_assembly != null)
			//	_assembly.Save();
			project.Changed = false;
		}
	}
}