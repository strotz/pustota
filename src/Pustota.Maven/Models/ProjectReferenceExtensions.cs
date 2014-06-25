using System;
using System.Dynamic;

namespace Pustota.Maven.Models
{
	public interface IProjectReferenceOperations
	{
		bool HasSpecificVersion { get; }
		bool IsSnapshot { get; }
		void SwitchToRelease(string postfix = null);
		bool ReferenceEqualTo(IProjectReference another, bool strictVersion = true);
	}

	internal class ProjectReferenceOperations : IProjectReferenceOperations
	{
		private readonly IProjectReference _projectReference;

		public ProjectReferenceOperations(IProjectReference projectReference)
		{
			_projectReference = projectReference;
		}

		public bool ReferenceEqualTo(IProjectReference another, bool strictVersion = true)
		{
			return
				GroupIdEqual(_projectReference.GroupId, another.GroupId) &&
				_projectReference.ArtifactId.Equals(another.ArtifactId, StringComparison.Ordinal) &&
				((strictVersion == false) || VersionEqual(_projectReference.Version, another.Version));
		}

		public bool HasSpecificVersion
		{
			get { return !string.IsNullOrEmpty(_projectReference.Version); }
		}

		public bool IsSnapshot
		{
			get { return HasSpecificVersion
				&& _projectReference.Version.ToUpper().EndsWith(VersionOperations.SnapshotPosfix); }
		}

		public void SwitchToRelease(string postfix = null)
		{
			string version = VersionOperations.ResetVersion(_projectReference.Version);
			_projectReference.Version = VersionOperations.AddPostfix(version, postfix);
		}

		private static bool VersionEqual(string version1, string version2)
		{
			return NullableStringEqual(version1, version2);
		}

		private static bool GroupIdEqual(string group1, string group2) //
		{
			return NullableStringEqual(group1, group2);
		}

		private static bool NullableStringEqual(string value1, string value2)
		{
			if (value1 == null && value2 == null)
			{
				return true;
			}
			if (value1 == null || value2 == null)
			{
				return false;
			}
			return value1.Equals(value2, StringComparison.Ordinal);
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