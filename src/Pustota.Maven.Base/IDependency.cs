namespace Pustota.Maven.Base
{
	public interface IDependency : IProjectReference
	{
		string Classifier { get; set; }
		string Type { get; set; }
		string Scope { get; set; }
		bool? Optional { get; set; }
	}
}