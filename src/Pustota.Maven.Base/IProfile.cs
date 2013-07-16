using System.Collections.Generic;

namespace Pustota.Maven.Base
{
	public interface IProfile
	{
		string Id { get; set; }

		//ICollection<IDependency> Dependencies { get; }
		//ICollection<IProperty> Properties { get; }
		//ICollection<IModule> Modules { get; }
	}
}