namespace Pustota.Maven.Editor.Validations
{
	abstract class Fix
	{
		public string Title { get; set; }
		public bool ShouldBeConfirmed { get; set; }

		public abstract void Do();
	}
}
