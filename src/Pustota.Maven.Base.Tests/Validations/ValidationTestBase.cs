using Moq;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class ValidationTestBase
	{
		protected Mock<IProject> Project;
		protected Mock<IResolvedProjectData> ResolvedProjectData; 

//		protected Mock<IProjectsRepository> Repo;
		protected Mock<IExternalModulesRepository> Externals;
		protected Mock<IValidationContext> Context;

		protected void CreateContext()
		{
			Project = new Mock<IProject>();
			ResolvedProjectData = new Mock<IResolvedProjectData>();

//			Repo = new Mock<IProjectsRepository>();
			Externals = new Mock<IExternalModulesRepository>();

			Context = new Mock<IValidationContext>();
		}
	}
}