using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	internal class Plugin :
		ProjectReference,
		IPlugin
	{
		internal Plugin()
		{
			Executions = new BlackBox();
			Configuration = new BlackBox();
		}

		public bool Extensions { get; set; }
		public IBlackBox Executions { get; set; }
		public IBlackBox Configuration { get; set; }
	}
}