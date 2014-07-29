namespace Pustota.Maven.Validation
{
	abstract class Fix
	{
		public string Title { get; protected set; }
		public bool ShouldBeConfirmed { get; protected set; }

		public abstract void Do();
	}
}
