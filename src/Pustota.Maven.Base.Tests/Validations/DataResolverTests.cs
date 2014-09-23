using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Validation.Data;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class DataResolverTests
	{
		protected Mock<IProject> Project;

		[SetUp]
		public void Initialize()
		{
			Project = new Mock<IProject>();
		}

		[Test]
		public void ProjectHasVersionTest()
		{
			Project.Setup(p => p.Version).Returns("abc");
			var resolved = Loader.Resolve(Project.Object);
			Assert.That(resolved.Version, Is.Not.Empty);
		}
	}
}