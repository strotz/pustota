using System.Xml.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	public interface IDataFactory
	{
		IProject CreateProject();

		IParentReference CreateParentReference();

		IModule CreateModule();

		// REVIEW: change types
		IPlugin CreatePlugin(PomXmlElement element);
		IProfile CreateProfile(PomXmlElement element);
		IDependency CreateDependency(PomXmlElement element);
	}
}