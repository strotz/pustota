using Pustota.Maven.Models;

namespace Pustota.Maven
{
	internal class ExecutionContext : 
		ProjectTree,
		IExecutionContext
	{
		private readonly IPathCalculator _pathCalculator;

		protected ExecutionContext(IPathCalculator pathCalculator)
		{
			_pathCalculator = pathCalculator;
		}

		// TODO: test
		// TODO: it should not be here
		public bool TryGetParentByPath(IProject project, out IProject parent)
		{
			parent = null;

			FullPath currentProjectPath;
			if (!TryGetPathByProject(project, out currentProjectPath))
			{
				return false;
			}

			string parentRelativePath = (project.Parent != null && !string.IsNullOrEmpty(project.Parent.RelativePath)) ?
				project.Parent.RelativePath : "../pom.xml";

			var fullPath = _pathCalculator.CalculateParentPath(currentProjectPath, parentRelativePath);
			return TryGetProjectByPath(fullPath, out parent);
		}
	}
}