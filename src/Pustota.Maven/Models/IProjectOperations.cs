namespace Pustota.Maven.Models
{
	public interface IProjectOperations : 
		IProjectQueries
	{
		void PropagateVersionToUsages(IProjectReference projectReference);
	}
}