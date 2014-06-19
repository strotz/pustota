using System.Collections.Generic;

namespace Pustota.Maven.Models
{
	public interface IProject : 
		IProjectReference,
		IBuildContainer
	{
		string Name { get; set; }
		string Packaging { get; set; }

		List<IProfile> Profiles { get; set; }

		IParentReference Parent { get; set; }
	}
}
