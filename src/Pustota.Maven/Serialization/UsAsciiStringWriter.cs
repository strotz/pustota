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
}