using System;
using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven
{
	internal class ExternalModuleRepository : IExternalModuleRepository
	{
		private readonly IList<IExternalModule> _externalModules = new List<IExternalModule>();

		public IEnumerable<IExternalModule> AllExternalModules
		{
			get { return _externalModules; }
		}

		public bool IsExternalModule(IProjectReference projectReference)
		{
			var operation = projectReference.ReferenceOperations();
			return _externalModules.FirstOrDefault(i => operation.ReferenceEqualTo(i, true)) != null;
		}

		internal void Reset()
		{
			_externalModules.Clear();
		}

		internal void Add(IExternalModule externalModule)
		{
			_externalModules.Add(externalModule);
		}
	}

	internal class ExecutionContext : 
		ProjectTree,
		IExecutionContext
	{
		private readonly IPathCalculator _pathCalculator;


		protected ExecutionContext(IPathCalculator pathCalculator)
		{
			_pathCalculator = pathCalculator;
		}

		//// TODO: test
		//// TODO: it should not be here
		//public IEnumerable<IProject> BuildInheritanceChain(IProjectReference reference)
		//{
		//	IProject project;
		//	if (!TryGetProject(reference, out project))
		//	{
		//		throw new Exception();
		//	}

		//	var parentReference = project.Parent;
		//	if (parentReference == null)
		//	{
		//		return null;
		//	}

		//	IProject parent;
		//	if (!TryGetParent(project, out parentReference))
		//	{
		//		throw new Exception();
		//	}
		//}

		//// possible cases:
		//// project -> has parent reference
		//// project -> no parent reference => 
		//private bool TryGetParent(IProject project, out IParentReference parentReference)
		//{
		//	throw new NotImplementedException();

		//	var parentReference = project.Parent;
		//	if (parentReference == null)
		//	{
		//		return null;
		//	}

		//	var extractor = new ProjectDataExtractor();

		//	IProject parentByPath;
		//	if (context.TryGetParentByPath(project, out parentByPath))
		//	{
		//		var resolved = extractor.Extract(parentByPath);
		//		if (project.Operations().HasProjectAsParent(resolved))
		//		{
		//			OK
		//		}

		//		if (project.Operations().HasProjectAsParent(resolved, false))
		//		{
		//			WARNING
		//		}
		//	}

		//}
		
		// TODO: project reference ?
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

		// TODO: project reference ?
		public bool TryGetModule(IProject project, string moduleName, out IProject module)
		{
			module = null;

			FullPath currentProjectPath;
			if (!TryGetPathByProject(project, out currentProjectPath))
			{
				return false;
			}

			var fullPath = _pathCalculator.CalculateModulePath(currentProjectPath, moduleName);
			return TryGetProjectByPath(fullPath, out module);
		}

		public IEnumerable<IProjectReference> AllAvailableProjectReferences
		{
			get { return AllExtractedProjects.Concat(_externalModules); }
		}

		protected override void Reset()
		{
			base.Reset();
			//_externalModules.Clear();
		}

		protected virtual void Add(IExternalModule externalModule)
		{
			//_externalModules.Add(externalModule);
		}
	}
}