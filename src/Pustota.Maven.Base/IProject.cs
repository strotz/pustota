using System.Collections.Generic;

namespace Pustota.Maven.Base
{
	public interface IProject : IProjectReference
	{
/*
		IParentReference Parent { get; set; }
*/
		// string FullPath { get; }
		string Name { get; set; }
		string Packaging { get; set; }
		string ModelVersion { get; set; }
/*
		ICollection<IDependency> Dependencies { get; set; }
		ICollection<IProperty> Properties { get; set; }
		ICollection<IModule> Modules { get; set; }
		ICollection<IProfile> Profiles { get; set; }
		ICollection<IPlugin> Plugins { get; }
		ICollection<IPlugin> PluginManagement { get; }
*/	
//		IEnumerable<IModule> AllModules { get; }
//		IEnumerable<IDependency> AllDependencies { get; }
//		IEnumerable<IProperty> AllProperties { get; }
	}
}
