using Pustota.Maven.Models;
using System.Collections.Generic;

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
			Dependencies = new List<IDependency>();
		}

		public bool Extensions { get; set; }
		public IBlackBox Executions { get; set; }
		public IBlackBox Configuration { get; set; }
		public List<IDependency> Dependencies { get; set; }
	}
}