using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization
{
	public class ProjectTreeElement : IProjectTreeItem
	{
		public ProjectTreeElement()
		{
		}

		public ProjectTreeElement(FullPath path, IProject project)
		{
			Path = path;
			Project = project;
		}

		public IProject Project { get; set; }
		public FullPath Path { get; set; }
	}
}