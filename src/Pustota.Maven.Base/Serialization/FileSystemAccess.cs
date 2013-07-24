using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustota.Maven.Base.Serialization
{
	public class FileSystemAccess :
		IFileSystemAccess
	{
		public bool IsFileExist(string path)
		{
			return File.Exists(path);
		}

		public bool IsDirectoryExist(string path)
		{
			return Directory.Exists(path);
		}

		public string GetFullPath(string path)
		{
			return Path.GetFullPath(path);
		}

		public string GetDirectoryName(string path)
		{
			return Path.GetDirectoryName(path);
		}

		public IEnumerable<string> EnumerateDirectories(string directoryPath)
		{
			return Directory.EnumerateDirectories(directoryPath);	
		}

		public string Combine(string first, string second)
		{
			return Path.Combine(first, second);
		}

		public string Combine(string first, string second, string third)
		{
			return Path.Combine(first, second, third);
		}

		public string ReadAllText(string filePath)
		{
			return File.ReadAllText(filePath);
		}

		public void WriteAllText(string filePath, string content)
		{
			File.WriteAllText(filePath, content);
		}
	}
}
