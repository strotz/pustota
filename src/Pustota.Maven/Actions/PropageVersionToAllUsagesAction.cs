using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustota.Maven.Actions
{
	class PropageVersionToAllUsagesAction
	{
		public void Execute()
		{
			//string versionToPropagate = original.Version;

			//foreach (var projectNode in AllProjectNodes)
			//{
			//	projectNode.PropagateVersionToUsages(original);
			//}

			//foreach (var childPrj in FindProjectChildren(original))
			//{
			//	if (childPrj.Project.Parent.HasSpecificVersion && childPrj.Project.Parent.Version != versionToPropagate)
			//	{
			//		childPrj.Project.Parent.Version = versionToPropagate;
			//		childPrj.Changed = true;
			//	}
			//	PropagateVersionToAllUsages(childPrj);
			//}
		}

		//private IEnumerable<ProjectNode> FindProjectChildren(IProjectReference projectReference)
		//{
		//	return AllProjectNodes.Where(node =>
		//		node.Project.Parent != null &&
		//		node.Project.Parent.ReferenceEqualTo(projectReference, false));
		//}

	}
}
