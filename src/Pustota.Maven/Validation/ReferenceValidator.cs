using System.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	internal class ReferenceValidator
	{
		private readonly IExecutionContext _context;

		internal ReferenceValidator(IExecutionContext context)
		{
			_context = context;
		}

		internal IValidationProblem ValidateReference(IProject project, IProjectReference reference, string referenceTitle)
		{
			IProjectReferenceOperations operation = reference.ReferenceOperations();

			var potencial = _context.AllExtractedProjects.
				Where(p => operation.ReferenceEqualTo(p, false)).ToArray();

			if (potencial.Length == 0)
			{
				return new ValidationProblem // TODO: fixable
				{
					Severity = ProblemSeverity.ProjectWarning,
					Description = string.Format("Project {0} uses unknown {2} {1}", project, reference, referenceTitle)
				};
				//error.AddFix(new AddExternalModuleFix(_externalModules, dependency));
			}
			var exact = potencial.SingleOrDefault(p => operation.VersionEqualTo(p.Version));
			if (exact != null)
			{
				return null;
			}

			if (potencial.Length == 1)
			{
				return new ValidationProblem // TODO: fixable
				{
					Severity = ProblemSeverity.ProjectWarning,
					Description = string.Format("Project {0} uses different {2} version {1}", project, reference, referenceTitle)
				};
				//		error.AddFix(new ApplyVersionFix(_projectNode.Project, dependency, potencial.Single().Version));
			}
			return new ValidationProblem // TODO: fixable
			{
				Severity = ProblemSeverity.ProjectWarning,
				Description = string.Format("Project {0} {2} version {1} is wrong. Found multiple potencial candidates", project, reference, referenceTitle)
			};
			//		foreach (var candicate in potencial)
			//		{
			//			error.AddFix(new ApplyVersionFix(_projectNode.Project, dependency, candicate.Version));
			//		}
		}
	}
}