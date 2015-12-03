namespace Pustota.Maven
{
	public interface IPathCalculator
	{
		FullPath CalculateParentPath(FullPath currentPath, string relativePath);
		bool TryResolveModulePath(FullPath currentPath, string modulePath, out FullPath module);
	}
}