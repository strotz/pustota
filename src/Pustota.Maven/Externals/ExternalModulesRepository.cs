using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pustota.Maven.Editor.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven.Externals
{
	class ExternalModulesRepository // TODO: merge with ExternalModules 
	{
		private readonly string _baseDir;
		private const string ExternalModulesFileName = ".mavenexternal";

		private ExternalModules _allModules;

		internal ExternalModulesRepository(string baseDir)
		{
			_baseDir = baseDir;
			LoadExternalModules();
		}

		public ExternalModules AllModules
		{
			get { return _allModules; }
			set { _allModules = value; }
		}

		public bool Changed
		{
			get { return _allModules.Changed; }
			private set { _allModules.Changed = value; }
		}

		private void LoadExternalModules()
		{
			string path = Path.Combine(_baseDir, ExternalModulesFileName);
			_allModules = new ExternalModules(path);
			_allModules.LoadModules();
		}

		internal List<ExternalModule> Items
		{
			get { return _allModules.Items; }
		}

		public void Add(ExternalModule module)
		{
			if (Items.Any(m => m.ArtifactId == module.ArtifactId && m.GroupId == module.GroupId && m.Version == module.Version)) return;
			Changed = true;
			Items.Add(module);
		}

		public void Remove(ExternalModule module)
		{
			Changed = true;
			Items.Remove(module);
		}

		public bool Contains(IProjectReference reference, bool strictVersion)
		{
			return AllModules.Items.Any(m => m.ReferenceEqualTo(reference, strictVersion));
		}
	}
}