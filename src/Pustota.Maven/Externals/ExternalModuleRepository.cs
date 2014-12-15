using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Externals
{
	internal class ExternalModuleRepository : IExternalModuleRepository
	{
		private readonly IList<IExternalModule> _externalModules = new List<IExternalModule>();

		public IEnumerable<IExternalModule> All
		{
			get { return _externalModules; }
		}

		public bool Contains(IProjectReference projectReference)
		{
			var operation = projectReference.ReferenceOperations();
			return _externalModules.FirstOrDefault(i => operation.ReferenceEqualTo(i, true)) != null;
		}

		internal void Reset()
		{
			_externalModules.Clear();
		}

		internal void Add(IExternalModule externalModule)
		{
			_externalModules.Add(externalModule);
		}
	}
}