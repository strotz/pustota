using System.Collections.Generic;
using System.IO;

namespace Pustota.Maven.System
{
	public interface IFileSystemAccess
	{
		bool IsFileExist(string path);
		
		bool IsDirectoryExist(string path);
		
		string GetFullPath(string path);
		
		string GetDirectoryName(string path);

		IEnumerable<string> EnumerateDirectories(string directoryPath);

		string Combine(string first, string second);

		string Combine(string first, string second, string third);

		string ReadAllText(string filePath);

		void WriteAllText(string filePath, string content);
		
		void CreateDirectory(string path);

		string[] GetFiles(string path, string searchPattern, SearchOption searchOption);

		string GetRelativePath(string firstPath, string secondPath);

		bool ArePathesEqual(string path1, string path2);

		string Normalize(string path);
	}
}