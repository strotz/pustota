using System;
using Pustota.Maven.Models;

namespace Pustota.Maven.Editor.Models
{
	// TODO: review and redo (comparer, mockable)
	public static class ProjectReferenceOperations
	{
		public static bool ReferenceEqualTo(
			this IProjectReference one,
			IProjectReference another,
			bool strictVersion = true)
		{
			return
				GroupIdEqual(one.GroupId, another.GroupId) &&
				one.ArtifactId.Equals(another.ArtifactId, StringComparison.Ordinal) &&
				((strictVersion == false) || VersionEqual(one.Version, another.Version));
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
}