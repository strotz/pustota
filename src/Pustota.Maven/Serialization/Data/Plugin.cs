using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	internal class Plugin :
		ProjectReference,
		IPlugin
	{
		public bool Extensions { get; set; }
		public IBlackBox Executions { get; set; }
		public IBlackBox Configuration { get; set; }
	}
}