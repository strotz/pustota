using System;
using System.Globalization;

namespace Pustota.Maven.Models
{
	public struct ComponentVersion
	{
		public const string SnapshotPosfix = "-SNAPSHOT";
		public const string DefaultVersion = "1.0.0";

		private readonly string _value;

		public ComponentVersion(string value)
		{
			_value = value;
		}

		public string Value
		{
			get { return _value; }
		}

		public bool IsDefined
		{
			get { return !string.IsNullOrEmpty(_value); }
		}

		public bool IsSnapshot
		{
			get { return IsDefined && _value.EndsWith(SnapshotPosfix); }
		}

		public ComponentVersion SwitchToRelease(string postfix = null)
		{
			var normalized = NormalizeSuffix(postfix);

			if (!IsDefined)
			{
				return new ComponentVersion(DefaultVersion + normalized);
			}
			if (IsSnapshot)
			{
				return new ComponentVersion(_value.Substring(0, _value.Length - SnapshotPosfix.Length) + normalized);
			}
			return new ComponentVersion(_value + normalized);
		}

		public ComponentVersion SwitchToSnapshotWithVersionIncrement()
		{
			if (!IsDefined)
			{
				return new ComponentVersion(DefaultVersion + SnapshotPosfix);
			}
			if (IsSnapshot)
			{
				// nothing to do
				return new ComponentVersion(_value);
			}
			return new ComponentVersion(IncrementNumber(_value, 2) + SnapshotPosfix); // TODO: make it flexable
		}

		private static string NormalizeSuffix(string postfix)
		{
			if (string.IsNullOrEmpty(postfix))
			{
				return string.Empty;
			}
			if (postfix.StartsWith("-"))
			{
				return postfix;
			}
			return "-" + postfix;
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

		static public implicit operator ComponentVersion(string version) // TODO: remove 
		{
			return new ComponentVersion(version);
		}

		static public implicit operator string(ComponentVersion version)
		{
			return version.Value;
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
			return (_value != null ? _value.GetHashCode() : 0);
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