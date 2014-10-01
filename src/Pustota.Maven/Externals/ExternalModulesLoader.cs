using System.Collections.Generic;
using System.Xml.Linq;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Externals
{
	// TODO: test
	public interface IExternalModulesLoader
	{
		IEnumerable<IExternalModule> Load(string baseDir);
	}

	// TODO: test
	public class ExternalModulesLoader : IExternalModulesLoader
	{
		private const string ExternalModulesFileName = ".mavenexternal";

		private readonly IFileSystemAccess _fileIo;

		public ExternalModulesLoader(IFileSystemAccess fileIo)
		{
			_fileIo = fileIo;
		}

		public IEnumerable<IExternalModule> Load(string baseDir)
		{
			var fileName = _fileIo.Combine(baseDir, ExternalModulesFileName);
			if (!_fileIo.IsFileExist(fileName))
			{
				return new IExternalModule[] {};
			}

			var xdocument = XDocument.Load(fileName);
			var document = new ExternalModulesDocument(xdocument); // TODO: should be done via serializer  

			return document.ReadModules();
		}
	}
}