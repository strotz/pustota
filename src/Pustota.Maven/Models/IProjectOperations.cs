namespace Pustota.Maven.Models
{
	public interface IProjectOperations : 
		IProjectQueries,
		IProjectDataResolver
	{
		void PropagateVersionToUsages(IProjectReference projectReference);
	}
}