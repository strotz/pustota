using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]

	public class ProjectOperationsTests
	{
		private Mock<IProject> _project;
		private ProjectOperations _operation;
		private Mock<IParentReference> _parent;

		[SetUp]
		public void Setup()
		{
			_project = new Mock<IProject>();
			_parent = new Mock<IParentReference>();
			_operation = new ProjectOperations(_project.Object);
		}

		[Test]
		public void ExplicitVersionTest()
		{
			var version = "1.0.0-SNAPSHOT";
			_project.Setup(p => p.Version).Returns(version);
			Assert.That(_operation.ActualVersion, Is.EqualTo(new ComponentVersion(version)));
		}

		[Test]
		public void InheritedVersionTest()
		{
			var version = "1.0.0-SNAPSHOT";
			_project.Setup(p => p.Version).Returns(ComponentVersion.Undefined);

			_parent.Setup(p => p.Version).Returns(version);
			_project.Setup(p => p.Parent).Returns(_parent.Object);
			Assert.That(_operation.ActualVersion, Is.EqualTo(new ComponentVersion(version)));
		}
	}
}
