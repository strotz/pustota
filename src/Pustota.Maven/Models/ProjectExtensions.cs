using System;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Models
{
	public static class ProjectExtensions
	{
		internal static IFileSystemAccess FileSystem = new FileSystemAccess();

		internal static Func<IProject, IProjectOperations> OperationsFactory = project => new ProjectOperations(project, FileSystem);

		public static IProjectOperations Operations(this IProject project)
		{
			return OperationsFactory(project);
		}
	}
}