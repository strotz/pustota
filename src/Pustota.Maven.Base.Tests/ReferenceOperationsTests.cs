using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;

namespace Pustota.Maven.Base.Tests
{

	public class ReferenceOperationsTests
	{
		private Mock<IProjectReference> _project;
		private IProjectReferenceOperations _operations;

		[SetUp]
		public void Initialize()
		{
			_project = new Mock<IProjectReference>();
			_operations = new ProjectReferenceOperations(_project.Object);
		}

		[Test]
		public void ToReleaseFromNullBareTest()
		{
			_project.Setup(p => p.Version).Returns((string)null);
			string result = _operations.SwitchToRelease();
			Assert.That(result, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void ToReleaseFromSnapshotBareTest()
		{
			_project.Setup(p => p.Version).Returns("1.0.0-SNAPSHOT");
			string result = _operations.SwitchToRelease();
			Assert.That(result, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void ToReleaseFromReleaseBareTest() // TODO: should result be 1.0.0-RE
		{
			_project.Setup(p => p.Version).Returns("1.0.0-RE");
			string result = _operations.SwitchToRelease();
			Assert.That(result, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void ToReleaseFromReleaseWithSuffixTest()
		{
			_project.Setup(p => p.Version).Returns("1.0.0-RE");
			string result = _operations.SwitchToRelease("rel123");
			Assert.That(result, Is.EqualTo("1.0.0-rel123"));
		}

		[Test]
		public void ToSnapshotFromNullBareTest()
		{
			_project.Setup(p => p.Version).Returns((string)null);
			string result = _operations.IncrementVersionAndEnableSnapshot();
			Assert.That(result, Is.EqualTo("1.0.0-SNAPSHOT"));
		}

		[Test]
		public void ToSnapshotFromReleaseBareTest()
		{
			_project.Setup(p => p.Version).Returns("1.0.0");
			string result = _operations.IncrementVersionAndEnableSnapshot();
			Assert.That(result, Is.EqualTo("1.0.1-SNAPSHOT"));
		}

		[Test]
		public void ToSnapshotFromReleaseWithSuffixTest()
		{
			_project.Setup(p => p.Version).Returns("1.0.0-RE");
			string result = _operations.IncrementVersionAndEnableSnapshot();
			Assert.That(result, Is.EqualTo("1.0.1-SNAPSHOT"));
		}

	}
}
