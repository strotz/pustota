using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Pustota.Maven.Models
{
	public static class ComponentVersionExtensions
	{
		public static ComponentVersion ToVersion(this string stringValue)
		{
			return new ComponentVersion(stringValue);
		}

		public static VersionOperations Operations(this ComponentVersion version)
		{
			return new VersionOperations(version);
		}
	}

	public class VersionOperations
	{
		private readonly ComponentVersion _version;
		private readonly string _suffix;
		private readonly int[] _parts;

		public VersionOperations(ComponentVersion version)
		{
			if (!version.IsDefined)
			{
				throw new InvalidOperationException("version undefined");
			}
			_version = version;

			var value = version.Value;

			_suffix = "";
			int pos = value.IndexOf('-');
			if (pos >= 0)
			{
				_suffix = value.Substring(pos);
				value = value.Substring(0, pos);
			}

			_parts = ParseVersion(value).ToArray();
		}

		private static IEnumerable<int> ParseVersion(string versionValue)
		{
			return versionValue.Split('.').Select(part => int.Parse(part));
		}

		private int LastPosition => _parts.Length - 1;

		public ComponentVersion ToSnapshotWithVersionIncrement(int? position = null, int? stopAtPosition = null)
		{
			if (!_version.IsRelease)
			{
				throw new InvalidOperationException("version already in snapshot");
			}

			if (!position.HasValue)
			{
				position = LastPosition;
			}

			if (position.Value < 0 || position.Value > LastPosition)
			{
				throw new InvalidOperationException("wrong version increment");
			}

			var incremented = GetIncrementedParts(position.Value, stopAtPosition).Select(i => i.ToString(CultureInfo.InvariantCulture));
			var value = string.Join(".", incremented) + _suffix + ComponentVersion.SnapshotPosfix;

			return new ComponentVersion(value); 
		}

		private IEnumerable<int> GetIncrementedParts(int position, int? stopAtPosition = null)
		{
			int stop = _parts.Length;
			if (stopAtPosition.HasValue)
			{
				stop = Math.Min(stop, stopAtPosition.Value + 1);
			}

			for (int i = 0; i < stop; i++)
			{
				if (i < position)
				{
					yield return _parts[i];
				}
				else if (i == position)
				{
					yield return _parts[i] + 1;	
				}
				else
				{
					yield return 0;
				}
			}
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