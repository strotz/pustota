using System.Collections.Generic;

namespace Pustota.Maven.Models
{
	// REVIEW: rename
	public interface ICollected
	{
		IEnumerable<IModule> AllModules { get; }
		IEnumerable<IDependency> AllDependencies { get; }
		IEnumerable<IProperty> AllProperties { get; }
	}
}