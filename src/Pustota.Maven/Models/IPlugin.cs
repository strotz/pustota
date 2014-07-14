namespace Pustota.Maven.Models
{
	public interface IPlugin : IProjectReference
	{
		IBlackBox Executions { get; set; }
		IBlackBox Configuration { get; set; }
	}
}