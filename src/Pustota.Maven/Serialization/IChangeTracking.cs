namespace Pustota.Maven.Serialization
{
	public delegate void OnChangeEventHandler(object sender);

	public interface IChangeTracking
	{
		bool Changed { get; set; }
		event OnChangeEventHandler OnChange;
		void ListenChanged(IChangeTracking linked);
	}
}