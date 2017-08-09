using System.Collections.Generic;

namespace Pustota.Maven.Models
{
	public interface IPlugin : IProjectReference
	{
		bool Extensions { get; set; }
		IBlackBox Executions { get; set; }
		IBlackBox Configuration { get; set; }
		List<IDependency> Dependencies { get; set; }
	}
}