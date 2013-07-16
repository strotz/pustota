namespace Pustota.Maven.Base
{
	interface IItemBuilder<TItem>
	{
		TItem Create();
	}
}