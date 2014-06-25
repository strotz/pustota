using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Externals
{
	public interface IExternalModulesRepository
	{
		void Add(IExternalModule module);
		void Remove(IExternalModule module);
		bool Contains(IProjectReference reference, bool strictVersion);
		IEnumerable<IExternalModule> Items { get; }
	}
}