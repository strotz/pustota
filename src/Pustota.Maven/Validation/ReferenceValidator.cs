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

		// TODO: TEST
		internal IProjectValidationProblem ValidateReference(IProject project, IProjectReference reference, string referenceTitle)
		{
			IProjectReferenceOperations operation = reference.ReferenceOperations();

			var potencial = _context.AllAvailableProjectReferences.
				Where(p => operation.ReferenceEqualTo(p, false)).ToArray();

			if (potencial.Length == 0)
			{
				return new ValidationProblem(referenceTitle + "missing") // TODO: fixable
				{
					ProjectReference = project,
					Severity = ProblemSeverity.ProjectWarning,
					Description = string.Format("uses unknown {0} {1}", referenceTitle, reference)
				};
				//error.AddFix(new AddExternalModuleFix(_externalModules, dependency));
			}

			// REVIEW: First is enougth
			// REVIEW: many exact matches is not a problem of project reference, but need to be catched differently 
			var exact = potencial.FirstOrDefault(p => operation.VersionEqualTo(p.Version));
			if (exact != null)
			{
				return null;
			}

			if (potencial.Length == 1)
			{
				return new ValidationProblem(referenceTitle + "versionmissmatch") // TODO: fixable
				{
					ProjectReference = project,
					Severity = ProblemSeverity.ProjectWarning,
					Description = string.Format("version of {0} different from {1}", referenceTitle, reference)
				};
				//		error.AddFix(new ApplyVersionFix(_projectNode.Project, dependency, potencial.Single().Version));
			}
			return new ValidationProblem(referenceTitle + "version") // TODO: fixable
			{
				ProjectReference = project,
				Severity = ProblemSeverity.ProjectWarning,
				Description = string.Format("version of {0} different from {1}. Found multiple potencial candidates", referenceTitle, reference)
			};
			//		foreach (var candicate in potencial)
			//		{
			//			error.AddFix(new ApplyVersionFix(_projectNode.Project, dependency, candicate.Version));
			//		}
		}
	}
}