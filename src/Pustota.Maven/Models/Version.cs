namespace Pustota.Maven.Models
{
	public struct Version
	{
		private readonly string _value;

		public Version(string value)
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

		static public implicit operator Version(string version) // TODO: remove 
		{
			return new Version(version);
		}

		static public implicit operator string(Version version)
		{
			return version.Value;
		}

		public bool Equals(Version other)
		{
			return string.Equals(_value, other._value);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			return obj is Version && Equals((Version)obj);
		}

		public override int GetHashCode()
		{
			return (_value != null ? _value.GetHashCode() : 0);
		}

		public static bool operator ==(Version a, Version b)
		{
			return a._value == b._value;
		}

		public static bool operator !=(Version a, Version b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			return _value;
		}
	}
}