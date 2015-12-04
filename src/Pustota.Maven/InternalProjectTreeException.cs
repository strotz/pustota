using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustota.Maven
{
	public class InternalProjectTreeException : Exception
	{
		public InternalProjectTreeException(string message, Exception innerException) :
			base(message, innerException)
		{
		}
	}
}
