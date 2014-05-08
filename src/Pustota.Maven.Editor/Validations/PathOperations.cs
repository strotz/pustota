using System;
using System.IO;

namespace Pustota.Maven.Editor.Validations
{
	internal class PathOperations
	{
		internal static string GetRelativePath(string firstPath, string secondPath)
		{
			Uri firstUri = new Uri(firstPath);
			Uri secondUri = new Uri(secondPath);
			return Uri.UnescapeDataString(firstUri.MakeRelativeUri(secondUri).ToString());
		}

		// REVIEW: comparer?
		public static bool ArePathesEqual(string path1, string path2)
		{
			return String.Equals(Path.GetFullPath(path1), Path.GetFullPath(path2), StringComparison.InvariantCultureIgnoreCase);
		}

		public static string Normalize(string path)
		{
			return path.Replace('/', Path.DirectorySeparatorChar);
		}
	}
}
