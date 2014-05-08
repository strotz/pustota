using System.Collections.Generic;

namespace Pustota.Maven.Editor.Validations
{
	public interface IFixable 
	{
		// REVIEW: why?  
		string Title { get; }
		string FullPath { get; }
		bool Changed { get; }
	}
}
