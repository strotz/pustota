namespace Pustota.Maven
{
	public interface IActionLog
	{
		void WriteMessage(string messageFormat, params object[] args);
	}
}