using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	internal class BlackBox
	{
		private PomElement Value;
	}

	internal class Plugin :
		ProjectReference,
		IPlugin
	{
		private BlackBox Executions { get; set; }
		private BlackBox Configuration { get; set; }
	}
}