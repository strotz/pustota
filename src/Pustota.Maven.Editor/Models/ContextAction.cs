using System;
using Pustota.Maven.Models;

namespace Pustota.Maven.Editor.Models
{
	class ContextAction
	{
		public string Title { get; set; }
		public IProject Source { get; set; }

		public Predicate<IProject> IsApplicable { get; set; }
		public Action<IProject> DelegatedAction { get; set; }

		public void Do()
		{
			DelegatedAction(Source);
		}
	}
}
