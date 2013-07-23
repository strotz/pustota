using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Base.Data;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ProjectContainerTests
	{
		private Mock<IProject> _project;

		[SetUp]
		public void Setup()
		{
			_project = new Mock<IProject>();
		}

		[Test]
		public void AllModulesTest()
		{
			_project.Setup(p => p.Modules).Returns(new List<Module>());
			var container = new ProjectContainer(null, _project.Object);
		}
	}
}
