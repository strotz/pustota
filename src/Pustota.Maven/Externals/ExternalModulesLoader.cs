using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Externals
{
	// TODO: test
	public interface IExternalModulesController
	{
		IExternalModulesRepository Load(string filepath);
	}

	// TODO: test
	public class ExternalModulesLoader : IExternalModulesController
	{
		private readonly IFileSystemAccess _fileIo;

		public ExternalModulesLoader(IFileSystemAccess fileIo)
		{
			_fileIo = fileIo;
		}

		//private const string ExternalModulesFileName = ".mavenexternal";

		//private void LoadExternalModules()
		//{
		//	string path = Path.Combine(_baseDir, ExternalModulesFileName);
		//	_allModules = new ExternalModules(path);
		//	_allModules.LoadModules();
		//}
		public IExternalModulesRepository Load(string filepath)
		{
			throw new System.NotImplementedException();
		}
	}
}