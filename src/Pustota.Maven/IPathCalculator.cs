namespace Pustota.Maven
{
	public interface IPathCalculator
	{
		FullPath CalculateParentPath(FullPath currentPath, string relativePath);
	}
}