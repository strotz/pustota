using System;

namespace Pustota.Maven.Models
{
	public static class ProjectExtensions
	{
		internal static Func<IProject, IAggregatedProject> AggregatedFactory = project => new AggregatedProject(project);

		public static IAggregatedProject Aggregated(this IProject project)
		{
			return AggregatedFactory(project);
		}
	}
}