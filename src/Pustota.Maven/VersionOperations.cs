using Pustota.Maven.Models;

namespace Pustota.Maven
{
	// REVIEW: to the IProjectReference extension
	public static class VersionOperations
	{
		private const string SnapshotPosfix = "-SNAPSHOT";
		public const string DefaultVersion = "1.0.0";

		public static bool IsSnapshot(this string version)
		{
			return version != null && version.ToUpper().EndsWith(SnapshotPosfix);
		}

		public static bool HasSpecificVersion(this IProjectReference reference)
		{
			return !string.IsNullOrEmpty(reference.Version);
		}

		public static bool IsSnapshot(this IProjectReference reference)
		{
			return reference.HasSpecificVersion() && reference.Version.ToUpper().EndsWith(SnapshotPosfix);
		}

		public static string ToSnapshot(this string version)
		{
			return AddPostfix(version, SnapshotPosfix);
		}

		public static string FromSnapshot(this string version)
		{
			return version.Substring(0, version.Length - SnapshotPosfix.Length);
		}

		public static string IncrementNumber(string version, int position)
		{
			string postfix = "";
			int pos = version.IndexOf('-');
			if (pos >= 0)
			{
				postfix = version.Substring(pos);
				version = version.Substring(0, pos);
			}
			string[] data = version.Split('.');

			for (int i = 0; i < data.Length; i++)
			{
				int value = int.Parse(data[i]);
				if (i == position)
				{
					data[i] = (value + 1).ToString();
				}
				else if (i > position)
				{
					data[i] = "0";
				}
			}

			return string.Join(".", data) + postfix;
		}

		public static string ResetVersion(string version)
		{
			if (string.IsNullOrEmpty(version))
			{
				return DefaultVersion;
			}
			int pos = version.IndexOf('-');
			if (pos >= 0)
			{
				return version.Substring(0, pos);
			}
			return version;
		}

		public static string AddPostfix(string version, string postfix)
		{
			if (string.IsNullOrEmpty(version))
			{
				version = DefaultVersion;
			}
			return string.IsNullOrEmpty(postfix) ? version : version	+ postfix;
		}
	}
}