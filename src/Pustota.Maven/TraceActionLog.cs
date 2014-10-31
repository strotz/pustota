using System.Diagnostics;

namespace Pustota.Maven
{
	class TraceActionLog : IActionLog
	{
		public void WriteMessage(string messageFormat, params object[] args)
		{
			string message = string.Format(messageFormat, args);
			Trace.WriteLine(message);
		}
	}
}
