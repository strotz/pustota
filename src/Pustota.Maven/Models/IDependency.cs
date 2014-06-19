namespace Pustota.Maven.Models
{
	public interface IDependency : IProjectReference
	{
		string Classifier { get; set; }
		string Type { get; set; }
		string Scope { get; set; }
		string ToString();
		bool Optional { get; set; }
	}
}