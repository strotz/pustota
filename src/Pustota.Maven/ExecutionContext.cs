using System;
using System.Collections.Generic;
using Pustota.Maven.Models;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven
{
	internal class ExecutionContext : 
		ProjectTree,
		IExecutionContext
	{
		private readonly IDictionary<IProject, IResolvedProjectData> _resolved;
		private readonly ProjectDataExtractor _extractor;

		private readonly IPathCalculator _pathCalculator;

		protected ExecutionContext(IFileSystemAccess system, IPathCalculator pathCalculator)
		{
			_resolved = new Dictionary<IProject, IResolvedProjectData>();
			_extractor = new ProjectDataExtractor(system);
			_pathCalculator = pathCalculator;
		}

		public IResolvedProjectData GetResolvedData(IProject project)
		{
			return _resolved[project];
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

			string relativePath = GetResolvedData(project).RelativeParentPath;
			var fullPath = _pathCalculator.CalculateParentPath(currentProjectPath, relativePath);
			return TryGetProjectByPath(fullPath, out parent);
		}

		protected override void Reset()
		{
			base.Reset();
			_resolved.Clear();
		}

		protected override void Add(IProjectTreeItem item)
		{
			base.Add(item);
			var data = _extractor.Extract(item.Project);
			_resolved.Add(item.Project, data);
		}
	}
}