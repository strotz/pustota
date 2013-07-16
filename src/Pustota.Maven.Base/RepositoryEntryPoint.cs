using System;
using System.IO;

namespace Pustota.Maven.Base
{
	internal class RepositoryEntryPoint
	{
		private readonly bool _fileBased;
		private readonly string _entryPath;
		private readonly string _basePath;
		
		internal string EntryPath
		{
			get { return _entryPath; }
		}

		internal string BasePath
		{
			get { return _basePath; }
		}

		internal bool FileBased
		{
			get { return _fileBased; }
		}

		internal RepositoryEntryPoint(string fileOrFolderName)
		{
			if (File.Exists(fileOrFolderName)) // there is a pom file selected
			{
				_fileBased = true;
			}
			else if (Directory.Exists(fileOrFolderName)) // some folder selected
			{
				_fileBased = false;
			}
			else
			{
				throw new FileNotFoundException(fileOrFolderName);
			}
			_entryPath = Path.GetFullPath(fileOrFolderName);
			_basePath = _fileBased ? Path.GetDirectoryName(EntryPath) : _entryPath;
			if (string.IsNullOrEmpty(BasePath))
			{
				throw new ArgumentException("BasePath cannot be null or empty");
			}
		}

		internal string GetFileFromBaseFolder(string fileName)
		{
			return Path.Combine(BasePath, fileName);
		}
	}
}