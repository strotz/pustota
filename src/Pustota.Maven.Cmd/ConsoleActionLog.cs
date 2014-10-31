using System;

namespace Pustota.Maven.Cmd
{
	class ConsoleActionLog : IActionLog
	{
		public void WriteMessage(string messageFormat, params object[] args)
		{
			Console.WriteLine(messageFormat, args);
		}
	}
}
