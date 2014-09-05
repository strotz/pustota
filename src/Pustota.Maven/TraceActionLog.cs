using System.Diagnostics;

namespace Pustota.Maven
{
	class TraceActionLog :
		IActionLog
	{
		public void WriteMessage(string message)
		{
			Trace.WriteLine(message);
		}
	}
}
