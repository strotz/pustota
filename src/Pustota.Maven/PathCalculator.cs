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

		public bool TryResolveModulePath(FullPath currentProjectPath, string moduleTagValue, out FullPath modulePath)
		{
			string moduleNormalized = _system.Normalize(moduleTagValue);
			string projectFolder = _system.GetDirectoryName(currentProjectPath);
			string moduleFolder = _system.Combine(projectFolder, moduleNormalized); // <module>ABC</module> is reference to project folder
			string combined = _system.IsDirectoryExist(moduleFolder) ? _system.Combine(moduleFolder, ProjectFilePattern) : moduleFolder; // sometimes module value includes file name
			string full = _system.GetFullPath(combined);
			if (_system.IsFileExist(full))
			{
				modulePath = new FullPath(full);
				return true;
			}
			modulePath = FullPath.Undefined;
			return false;
		}
	}
}