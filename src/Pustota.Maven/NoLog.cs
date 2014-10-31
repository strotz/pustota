namespace Pustota.Maven
{
	public class NoLog : IActionLog
	{
		public static IActionLog Instance { get; private set; }

		static NoLog()
		{
			Instance = new NoLog();
		}

		public void WriteMessage(string messageFormat, params object[] args)
		{
		}
	}
}