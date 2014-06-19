using System.Xml.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	public interface IDataFactory
	{
		IProject CreateProject();

		// REVIEW: change types
		IParentReference CreateParentReference(PomXmlElement parentNode);
		IPlugin CreatePlugin(PomXmlElement element);
		IProfile CreateProfile(PomXmlElement element);
		IDependency CreateDependency(PomXmlElement element);
	}
}