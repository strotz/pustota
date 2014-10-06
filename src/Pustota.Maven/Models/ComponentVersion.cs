using System;
using System.Globalization;

namespace Pustota.Maven.Models
{
	public struct ComponentVersion
	{
		public const string SnapshotPosfix = "-SNAPSHOT";
		public const string DefaultVersion = "1.0.0";

		private string _value;

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

		public void SwitchToRelease()
		{
			if (!IsDefined)
			{
				_value = DefaultVersion;
			}
			else if (IsSnapshot)
			{
				_value = _value.Substring(0, _value.Length - SnapshotPosfix.Length);
			}
		}

		public void SwitchToSnapshotWithVersionIncrement()
		{
			if (!IsDefined)
			{
				_value = DefaultVersion + SnapshotPosfix;
			}
			else if (IsSnapshot)
			{
				// nothing to do
			}
			else
			{
				if (_value.Contains("-"))
				{
					_value = _value + SnapshotPosfix;
				}
				else
				{
					_value = IncrementNumber(_value, 2) + SnapshotPosfix; // TODO: make it flexable
				}
			}
		}

		public void AddPostfix(string postfix)
		{
			if (!IsDefined)
			{
				_value = DefaultVersion;
			}

			if (string.IsNullOrEmpty(postfix))
			{
				return;
			}
			if (postfix.StartsWith("-"))
			{
				_value = _value + postfix;
			}
			else
			{
				_value = _value + "-" + postfix;
			}
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