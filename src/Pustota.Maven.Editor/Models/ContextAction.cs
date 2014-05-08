using System;

namespace Pustota.Maven.Editor.Models
{
	class ContextAction
	{
		public string Title { get; set; }
		public Project Source { get; set; }

		public Predicate<Project> IsApplicable { get; set; }
		public Action<Project> DelegatedAction { get; set; }

		public void Do()
		{
			DelegatedAction(Source);
		}
	}
}
