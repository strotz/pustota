using System;

namespace Pustota.Maven.Editor.Validations
{
	class DelegatedFix : Fix
	{
		public Action DelegatedAction { get; set; }

		public override void Do()
		{
			DelegatedAction();
		}
	}
}