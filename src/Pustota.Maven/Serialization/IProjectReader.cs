using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization
{
	public interface IProjectReader
	{
		IProject ReadProject(string path);
	}
}