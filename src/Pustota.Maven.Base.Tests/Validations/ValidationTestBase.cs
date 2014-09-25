using Moq;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class ValidationTestBase
	{
		protected Mock<IProject> Project;
		protected Mock<IExternalModulesRepository> Externals;
		protected Mock<IExecutionContext> Context;

		protected void CreateContext()
		{
			Project = new Mock<IProject>();
			Externals = new Mock<IExternalModulesRepository>();
			Context = new Mock<IExecutionContext>();
		}
	}
}