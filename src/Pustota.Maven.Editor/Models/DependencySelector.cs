using System.Collections.Generic;

namespace Pustota.Maven.Editor.Models
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

		internal IEnumerable<ProjectNode> SelectUsages(ProjectNode inputNodes)
		{
			return SelectUsages(new[] {inputNodes});
		}

		internal IEnumerable<ProjectNode> SelectUsages(IEnumerable<ProjectNode> inputNodes)
		{
			var nodesToCheck = new Queue<ProjectNode>(inputNodes);

			HashSet<ProjectNode> checkedProjects = new HashSet<ProjectNode>();
			HashSet<ProjectNode> result = new HashSet<ProjectNode>(); 

			while (nodesToCheck.Count != 0)
			{
				var nodeToFind = nodesToCheck.Dequeue();

				if (checkedProjects.Contains(nodeToFind))
					continue;

				checkedProjects.Add(nodeToFind);

				foreach (ProjectNode node in _repository.AllProjectNodes)
				{
					if (node.UsesProjectAs(nodeToFind, _creteria))
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