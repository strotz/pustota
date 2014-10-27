using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	internal class BlackBox : IBlackBox
	{
		internal BlackBox()
		{
			Value = null;
		}

		internal BlackBox(object value)
		{
			Value = value;
		}

		public bool IsEmpty
		{
			get { return Value == null; }
		}

		public object Value { get; private set; }
	}
}