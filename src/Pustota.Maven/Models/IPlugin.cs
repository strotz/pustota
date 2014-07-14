namespace Pustota.Maven.Models
{
	public interface IPlugin : IProjectReference
	{
		bool Extensions { get; set; }
		IBlackBox Executions { get; set; }
		IBlackBox Configuration { get; set; }
	}
}