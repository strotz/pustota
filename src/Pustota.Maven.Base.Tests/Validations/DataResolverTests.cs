using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class DataResolverTests
	{
		protected Mock<IProject> Project;
		
		private Mock<IFileSystemAccess> _system;
		private ProjectDataExtractor _extractor;

		[SetUp]
		public void Initialize()
		{
			Project = new Mock<IProject>();
			_system = new Mock<IFileSystemAccess>();
			_extractor = new ProjectDataExtractor(_system.Object);
		}

		[Test]
		public void ProjectHasVersionTest()
		{
			Project.Setup(p => p.Version).Returns("abc");
			var resolved = _extractor.Extract(Project.Object);
			Assert.That(resolved.Version, Is.Not.Empty);
		}
	}
}