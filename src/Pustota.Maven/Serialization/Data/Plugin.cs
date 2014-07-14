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

	internal class Plugin :
		ProjectReference,
		IPlugin
	{
		public IBlackBox Executions { get; set; }
		public IBlackBox Configuration { get; set; }
	}
}