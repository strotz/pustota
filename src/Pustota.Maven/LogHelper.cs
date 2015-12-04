namespace Pustota.Maven
{
	public static class LogHelper
	{
		public static void Info(this IActionLog log, string messageFormat, params object[] args)
		{
			log.WriteMessage("INFO:" + messageFormat, args);
		}

		public static void Warning(this IActionLog log, string messageFormat, params object[] args)
		{
			log.WriteMessage("WARNING:" + messageFormat, args);
		}
	}
}