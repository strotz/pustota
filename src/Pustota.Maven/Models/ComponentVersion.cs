using System;
using System.Globalization;

namespace Pustota.Maven.Models
{
    public static class ComponentVersionExtensions
    {
        public static ComponentVersion ToVersion(this string stringValue)
        {
            return new ComponentVersion(stringValue);
        } 
    } 


    public struct ComponentVersion
	{
		public const string SnapshotPosfix = "-SNAPSHOT";
		public const string DefaultVersion = "1.0.0";

		private readonly string _value;

		public ComponentVersion(string value)
		{
			_value = value;
		}

		public string Value => _value;

		public bool IsDefined => !string.IsNullOrEmpty(_value);

		public bool IsSnapshot => IsDefined && _value.EndsWith(SnapshotPosfix);

		public bool IsRelease => IsDefined && !_value.EndsWith(SnapshotPosfix);

		public static ComponentVersion Undefined => new ComponentVersion();

		public ComponentVersion SwitchSnapshotToRelease(long? build = null, string postfix = null)
		{
			if (!IsDefined)
			{
				throw new InvalidOperationException("version undefined");
			}
			if (IsSnapshot)
			{
				var normalized = NormalizeSuffix(postfix, build);
				return new ComponentVersion(_value.Substring(0, _value.Length - SnapshotPosfix.Length) + normalized);
			}
			throw new InvalidOperationException("version already in release");
		}

        public ComponentVersion SwitchSnapshotToRelease(ComponentVersion anotherVersion)
        {
            if (!IsDefined)
            {
                throw new InvalidOperationException("version undefined");
            }
            if (!anotherVersion.IsDefined)
            {
                throw new InvalidOperationException("target version undefined");
            }
            if (anotherVersion.IsSnapshot)
            {
                throw new InvalidOperationException("targer version is SNAPSHOT");
            }
            if (IsSnapshot)
            {
                string v = _value.Substring(0, _value.Length - SnapshotPosfix.Length);
                if (!anotherVersion.Value.StartsWith(v))
                {
                    throw new InvalidOperationException($"release version must extend snapshot. {anotherVersion.Value} does not start with {v}");
                }
                return new ComponentVersion(anotherVersion.Value);
            }
            throw new InvalidOperationException("version already in release");
        }

        public ComponentVersion SwitchReleaseToSnapshotWithVersionIncrement()
		{
			if (!IsDefined)
			{
				throw new InvalidOperationException("version undefined");
			}
			if (IsRelease)
			{
				return new ComponentVersion(IncrementNumber(_value, 2) + SnapshotPosfix); // TODO: make it flexable
			}
			throw new InvalidOperationException("version already in snapshot");
		}

		private static string NormalizeSuffix(string postfix, long? build)
		{
			string result = build.HasValue ? "." + build.Value : string.Empty;
			if (!string.IsNullOrEmpty(postfix))
			{
				if (postfix.StartsWith("-"))
				{
					result += postfix;
				}
				else
				{
					result += "-" + postfix;
				}
			}
			return result;
		}

		private static string IncrementNumber(string version, int position)
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
					data[i] = (value + 1).ToString(CultureInfo.InvariantCulture);
				}
				else if (i > position)
				{
					data[i] = "0";
				}
			}

			return string.Join(".", data) + postfix;
		}

		public bool Equals(ComponentVersion other)
		{
			return string.Equals(_value, other._value, StringComparison.Ordinal);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			return obj is ComponentVersion && Equals((ComponentVersion)obj);
		}

		public override int GetHashCode()
		{
			return _value?.GetHashCode() ?? 0;
		}

		public static bool operator ==(ComponentVersion a, ComponentVersion b)
		{
			return a._value == b._value;
		}

		public static bool operator !=(ComponentVersion a, ComponentVersion b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			return _value;
		}
	}
}