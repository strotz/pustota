namespace Pustota.Maven.Editor.Models
{
	internal interface IProjectLoader
	{
		Project LoadProject(string path); // REVIEW: IProject?
		void SaveProject(Project project, string path); // REVIEW: IProject?
	}
}