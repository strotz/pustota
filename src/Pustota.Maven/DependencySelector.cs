using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven
{
	internal class DependencySelector // TODO: TDD
	{
		private readonly IProjectsRepository _repository;
		private readonly SearchOptions _creteria;

		public DependencySelector(IProjectsRepository repository, SearchOptions creteria)
		{
			_repository = repository;
			_creteria = creteria;
		}

		internal IEnumerable<IProject> SelectUsages(IProjectReference inputNodes)
		{
			return SelectUsages(new[] {inputNodes});
		}

		internal IEnumerable<IProject> SelectUsages(IEnumerable<IProjectReference> inputNodes)
		{
			var nodesToCheck = new Queue<IProjectReference>(inputNodes);

			// REVIEW: do we need comparer 
			HashSet<IProjectReference> checkedProjects = new HashSet<IProjectReference>();
			HashSet<IProject> result = new HashSet<IProject>(); 

			while (nodesToCheck.Count != 0)
			{
				var nodeToFind = nodesToCheck.Dequeue();

				if (checkedProjects.Contains(nodeToFind))
					continue;

				checkedProjects.Add(nodeToFind);

				foreach (IProject node in _repository.AllProjects)
				{
					if (node.Operations().UsesProjectAs(nodeToFind, _creteria))
					{
						if (!_creteria.OnlyDirectUsages)
						{
							nodesToCheck.Enqueue(node);
						}
						result.Add(node);
					}
				}
			}

			return result;
		}
	}
}