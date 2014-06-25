using System;
using System.Collections.Generic;
using System.Xml;
using Pustota.Maven.Models;

namespace Pustota.Maven.Externals
{
	class ExternalModules : IExternalModulesRepository
	{
		private readonly List<IExternalModule> _modules;

		public bool Changed { get; private set; }

		public ExternalModules()
		{
			_modules = new List<IExternalModule>();
		}

		public void Add(IExternalModule module)
		{
			//if (Items.Any(m => m.ArtifactId == module.ArtifactId && m.GroupId == module.GroupId && m.Version == module.Version)) return;
			//Changed = true;
			//Items.Add(module);
			throw new NotImplementedException();
		}

		public void Remove(IExternalModule module)
		{
			throw new NotImplementedException();
			//Changed = true;
			//Items.Remove(module);
		}

		public bool Contains(IProjectReference reference, bool strictVersion)
		{
			throw new NotImplementedException();
			//return AllModules.Items.Any(m => m.ReferenceEqualTo(reference, strictVersion));
		}

		public IEnumerable<IExternalModule> Items
		{
			get { return _modules; }
		}

	}
}
