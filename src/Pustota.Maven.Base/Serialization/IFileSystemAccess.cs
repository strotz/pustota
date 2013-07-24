using System.Collections.Generic;

namespace Pustota.Maven.Base.Serialization
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
	}
}