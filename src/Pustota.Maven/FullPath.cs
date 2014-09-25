using System;

namespace Pustota.Maven
{
	public struct FullPath
	{
		private readonly string _value;

		internal FullPath(string value)
		{
			if (value == null)
				throw new ArgumentNullException("value");

			_value = value;
		}

		public string Value
		{
			get { return _value; }
		}

		// TODO: ensure that FullPath always contains full path value
		//public static FullPath Create(string path, IFileSystemAccess fileIo)
		//{
		//	return new FullPath(fileIo.GetFullPath(path));
		//}

		static public implicit operator string(FullPath fullPath)
		{
			return fullPath.Value;
		}

		public static FullPath Undefined
		{
			get { return new FullPath(String.Empty); }
		}
	}
}