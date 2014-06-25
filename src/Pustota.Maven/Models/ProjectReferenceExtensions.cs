using System;

namespace Pustota.Maven.Models
{
	public interface IProjectReferenceOperations
	{
		void SwitchToRelease(string postfix = null);
	}

	internal class ProjectReferenceOperations : IProjectReferenceOperations
	{
		private readonly IProjectReference _projectReference;

		public ProjectReferenceOperations(IProjectReference projectReference)
		{
			_projectReference = projectReference;
		}

		public void SwitchToRelease(string postfix = null)
		{
			string version = VersionOperations.ResetVersion(_projectReference.Version);
			_projectReference.Version = VersionOperations.AddPostfix(version, postfix);
		}
	}

	public static class ProjectReferenceExtensions
	{
		internal static Func<IProjectReference, IProjectReferenceOperations> ReferenceOperationsFactory = projectReference => new ProjectReferenceOperations(projectReference);

		public static IProjectReferenceOperations ReferenceOperations(this IProjectReference projectReference)
		{
			return ReferenceOperationsFactory(projectReference);
		}

		public static string GetProjectKey(this IProjectReference reference)
		{
			return string.Format("{0}:{1} ({2})", reference.GroupId, reference.ArtifactId, reference.Version);
		} 
	}
}