namespace Pustota.Maven.Base.Serialization
{
	public class RepositoryEntryPoint
	{
		private readonly string _entryPath;
		
		internal string EntryPath
		{
			get { return _entryPath; }
		}

		public RepositoryEntryPoint(string fileOrFolderName)
		{
			_entryPath = fileOrFolderName;
			
		}
	}
}