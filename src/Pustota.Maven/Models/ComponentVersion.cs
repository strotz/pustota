namespace Pustota.Maven.Models
{
	public struct ComponentVersion
	{
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
			get { return IsDefined && _value.EndsWith(VersionOperations.SnapshotPosfix); }
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
			return string.Equals(_value, other._value);
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