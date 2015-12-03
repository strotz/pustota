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

		public bool TryGetModule(IProject project, string moduleName, out IProject module)
		{
			module = null;

			FullPath currentProjectPath;
			if (!TryGetPathByProject(project, out currentProjectPath))
			{
				return false;
			}

			FullPath fullPath;
			if (_pathCalculator.TryResolveModulePath(currentProjectPath, moduleName, out fullPath))
			{
				return TryGetProjectByPath(fullPath, out module);
			}

			return false;
		}

		public IEnumerable<IExternalModule> AllExternalModules
		{
			get { return _externalModules; }
		}

		public bool IsExternalModule(IProjectReference projectReference)
		{
			var operation = projectReference.ReferenceOperations();
			return _externalModules.FirstOrDefault(i => operation.ReferenceEqualTo(i, true)) != null;
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