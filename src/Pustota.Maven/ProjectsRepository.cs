namespace Pustota.Maven
{
	class ProjectsRepository : IProjectsRepository
	{
		private readonly RepositoryEntryPoint _entryPoint;

		internal ProjectsRepository(string fileOrFolderName)
		{
			_entryPoint = new RepositoryEntryPoint(fileOrFolderName); // TODO: DI
		}
	}
}