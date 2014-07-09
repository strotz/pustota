using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization
{
	public class ProjectTreeElement
	{
		public ProjectTreeElement()
		{
		}

		public ProjectTreeElement(string path, IProject project)
		{
			Path = path;
			Project = project;
		}

		public IProject Project { get; set; }
		public string Path { get; set; }
	}
}