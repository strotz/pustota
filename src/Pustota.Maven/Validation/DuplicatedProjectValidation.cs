using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	class DuplicatedProjectValidation : IProjectValidator
	{
		public IEnumerable<ValidationProblem> Validate(IExecutionContext context, IProject project)
		{
			//if (_repository.AllProjectNodes
			//	.Any(p => p.ShareGroupAndArtifactWith(project) && p.FullPath != project.FullPath))
			//{
			//	string details = string.Format("There should not exist two or more different project files with the same maven coordinates (group id={0} and artifact id={1})", project.GroupId, project.ArtifactId);

			//	var error = new ValidationError(
			//		project,
			//		ErrorsResources.ProjectWithThisGroupAndArtifactIDAlreadyExistsInTree,
			//		details,
			//		ErrorLevel.Error);

			//	ValidationErrors.Add(error);
			//}

			throw new NotImplementedException();
		}
	}
}
