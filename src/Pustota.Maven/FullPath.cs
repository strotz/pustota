using Pustota.Maven.SystemServices;

namespace Pustota.Maven
{
	public sealed class FullPath
	{
		internal FullPath(string value)
		{
			Value = value;
		}

		public string Value { get; private set; }

		// TODO: ensure that FullPath always contains full path value
		public static FullPath Create(string path, IFileSystemAccess fileIo)
		{
			return new FullPath(fileIo.GetFullPath(path));
		}

		static public implicit operator string(FullPath fullPath)
		{
			return fullPath.Value;
		}
	}
}