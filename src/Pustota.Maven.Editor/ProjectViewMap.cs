using System.Collections.Generic;
using Pustota.Maven.Editor.Models;
using Pustota.Maven.Editor.ViewModels;

namespace Pustota.Maven.Editor
{
	//internal class ProjectViewMap
	//{
	//	private readonly Dictionary<ProjectNode, ProjectView> _projectNodeToView = new Dictionary<ProjectNode, ProjectView>();

	//	internal void Clean()
	//	{
	//		_projectNodeToView.Clear();
	//	}

	//	internal ProjectView GetProjectView(ProjectNode projectNode)
	//	{
	//		ProjectView result;
	//		if (!_projectNodeToView.TryGetValue(projectNode, out result))
	//		{
	//			result = new ProjectView(projectNode);
	//			_projectNodeToView[projectNode] = result;
	//		}
	//		return result;
	//	}


	//	internal IEnumerable<ProjectView> AllViews // REVIEW: review all queries 
	//	{
	//		get { return _projectNodeToView.Values; }
	//	}
	//}
}