using Moq;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class ValidationTestBase
	{
		protected Mock<IProject> Project;

		protected Mock<IExternalModuleRepository> ExternalModules; 
		protected Mock<IExecutionContext> Context;

		protected void CreateContext()
		{
			Project = new Mock<IProject>();
			ExternalModules = new Mock<IExternalModuleRepository>();
			Context = new Mock<IExecutionContext>();
			Context.Setup(c => c.ExternalModules).Returns(ExternalModules.Object);
		}
	}
}