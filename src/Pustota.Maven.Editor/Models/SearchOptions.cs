namespace Pustota.Maven.Editor.Models
{
	internal class SearchOptions
	{
		internal SearchOptions()
		{
		}

		internal bool LookForParents;
		internal bool LookForDependent;
		internal bool LookForPlugin;
		internal bool OnlyDirectUsages;
		internal bool StrictVersion;
	}
}