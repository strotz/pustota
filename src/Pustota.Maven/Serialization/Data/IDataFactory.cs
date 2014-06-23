using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	public interface IDataFactory
	{
		IProject CreateProject();

		IParentReference CreateParentReference();

		IProperty CreateProperty();

		IModule CreateModule();

		IDependency CreateDependency();

		// REVIEW: change types
		IPlugin CreatePlugin();
		IProfile CreateProfile();
		
	}
}