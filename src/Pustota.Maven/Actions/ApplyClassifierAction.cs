using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Actions
{
	public class ApplyClassifierAction
	{
		private readonly IProjectsRepository _projects;
		private readonly string _classifierName;
		private readonly string _classifierValue;

		public ApplyClassifierAction(IProjectsRepository projects, string classifierName, string classifierValue)
		{
			_projects = projects;
			_classifierName = classifierName;
			_classifierValue = classifierValue;
		}

		internal static string WrapProperty(string propertyName)
		{
			return "${" + propertyName + "}";
		}

		public void Execute()
		{
			string classifier = WrapProperty(_classifierName);

			foreach (var dependency in _projects.AllProjects.SelectMany(p => ProjectExtensions.Operations(p).AllDependencies).Where(d => d.Classifier == classifier))
			{
				dependency.Classifier = _classifierValue;
			}
		}
	}
}