using System.Collections.Generic;

namespace Pustota.Maven.Editor.Models
{
	public interface IProject : 
		IProjectReference,
		IBuildContainer
	{
		string FullPath { get; }

		bool Changed { get; set; }

		string Name { get; set; }
		string Packaging { get; set; }

		List<IProfile> Profiles { get; set; }

		IParentReference Parent { get; set; }

		IEnumerable<IModule> AllModules { get; }
		IEnumerable<IDependency> AllDependencies { get; }
		IEnumerable<IProperty> AllProperties { get; }
	}
}
