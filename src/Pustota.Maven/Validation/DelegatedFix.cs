using System;

namespace Pustota.Maven.Validation
{
	class DelegatedFix : Fix
	{
		DelegatedFix(Action action)
		{
			DelegatedAction = action;
		}

		private Action DelegatedAction { get; set; }

		public override void Do()
		{
			DelegatedAction();
		}
	}
}