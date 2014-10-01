using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Externals
{
	internal class ExternalModule : 
		ProjectReference,
		IExternalModule
		// IFixable
	{
		//[Browsable(false)]
		//public bool Changed { get; set; }

		internal ExternalModule()
		{
		}

	}
}
