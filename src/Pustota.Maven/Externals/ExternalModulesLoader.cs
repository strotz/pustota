using System.IO;

namespace Pustota.Maven.Externals
{
	public interface IExternalModulesController
	{
		IExternalModulesRepository Load(string filepath);
	}

	class ExternalModulesLoader // TODO: merge with ExternalModules 
	{
		//private readonly string _baseDir;
		//private const string ExternalModulesFileName = ".mavenexternal";

		//private ExternalModules _allModules;

		//internal ExternalModulesLoader(string baseDir)
		//{
		//	_baseDir = baseDir;
		//	LoadExternalModules();
		//}

		//private void LoadExternalModules()
		//{
		//	string path = Path.Combine(_baseDir, ExternalModulesFileName);
		//	_allModules = new ExternalModules(path);
		//	_allModules.LoadModules();
		//}
	}
}