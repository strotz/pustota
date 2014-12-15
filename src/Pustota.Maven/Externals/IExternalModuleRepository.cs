using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Externals
{
	public interface IExternalModuleRepository
	{
		IEnumerable<IExternalModule> All { get; }
		bool Contains(IProjectReference projectReference);
	}
}