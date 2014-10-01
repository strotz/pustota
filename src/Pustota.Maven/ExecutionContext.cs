using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven
{


	internal class ExecutionContext : 
		ProjectTree,
		IExecutionContext
	{
		private readonly IPathCalculator _pathCalculator;

		private readonly IList<IExternalModule> _externalModules; 

		protected ExecutionContext(IPathCalculator pathCalculator)
		{
			_pathCalculator = pathCalculator;
			_externalModules = new List<IExternalModule>();
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

		public IEnumerable<IProjectReference> AllAvailableProjectReferences
		{
			get { return AllExtractedProjects.Concat(_externalModules); }
		}

		protected override void Reset()
		{
			base.Reset();
			_externalModules.Clear();
		}

		protected virtual void Add(IExternalModule externalModule)
		{
			_externalModules.Add(externalModule);
		}
	}
}