using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	internal class BlackBox : IBlackBox
	{
		internal BlackBox(object value)
		{
			Value = value;
		}

		public object Value { get; private set; }
	}
}