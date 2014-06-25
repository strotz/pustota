using System;

namespace Pustota.Maven.Models
{
	public static class ProjectExtensions
	{
		internal static Func<IProject, IProjectOperations> OperationsFactory = project => new ProjectOperations(project);

		public static IProjectOperations Operations(this IProject project)
		{
			return OperationsFactory(project);
		}
	}
}