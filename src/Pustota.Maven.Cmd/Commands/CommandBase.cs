using CommandLine;

namespace Pustota.Maven.Cmd.Commands
{
	internal class CommandBase
	{
		[Option('v', "verbose", HelpText = "Enable verbose mode", DefaultValue = false)]
		public bool Verbose { get; set; }

		// TODO: it is dirty, nend  
		protected IActionLog GetActionLog()
		{
			if (Verbose)
			{
				return new ConsoleActionLog();
			}
			else
			{
				return NoLog.Instance;
			}
		}
	}
}