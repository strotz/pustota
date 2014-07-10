using System;
using System.IO;
using System.Text;

namespace Pustota.Maven.Serialization
{
	public class UsAsciiStringWriter : StringWriter
	{
		public UsAsciiStringWriter()
			: base((IFormatProvider)null)
		{
		}

		public override Encoding Encoding { get { return Encoding.ASCII; } }
	}

	public class Utf8StringWriter : StringWriter
	{
		public Utf8StringWriter()
			: base((IFormatProvider)null)
		{
		}

		public override Encoding Encoding { get { return Encoding.UTF8; } }
	}

}