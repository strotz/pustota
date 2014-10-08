using Pustota.Maven.SystemServices;

namespace Pustota.Maven
{
	internal class PathCalculator : IPathCalculator
	{
		public const string ProjectFilePattern = "pom.xml";

		private readonly IFileSystemAccess _system;

		public PathCalculator(IFileSystemAccess system)
		{
			_system = system;
		}

		public FullPath CalculateParentPath(FullPath currentPath, string relativePath)
		{
			string relativeNormalized = _system.Normalize(relativePath);
			string projectFolder = _system.GetDirectoryName(currentPath);
			string combined = _system.Combine(projectFolder, relativeNormalized);
			string full = _system.GetFullPath(combined);
			return new FullPath(full);
		}

		public FullPath CalculateModulePath(FullPath currentPath, string modulePath)
		{
			string moduleNormalized = _system.Normalize(modulePath);
			string projectFolder = _system.GetDirectoryName(currentPath);
			string combined = _system.Combine(projectFolder, moduleNormalized, ProjectFilePattern);
			string full = _system.GetFullPath(combined);
			return new FullPath(full);
		}
	}
}