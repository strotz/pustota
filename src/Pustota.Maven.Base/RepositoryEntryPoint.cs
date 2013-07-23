using System;
using System.IO;
using Pustota.Maven.Base.Serialization;

namespace Pustota.Maven.Base
{
	public class RepositoryEntryPoint
	{
		private readonly string _entryPath;
		
		internal string EntryPath
		{
			get { return _entryPath; }
		}

		public RepositoryEntryPoint(string fileOrFolderName, IFileSystemAccess fileIo)
		{
			_entryPath = fileIo.GetFullPath(fileOrFolderName);
		}
	}
}