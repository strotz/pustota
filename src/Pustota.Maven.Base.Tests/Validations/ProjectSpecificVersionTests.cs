using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class ProjectSpecificVersionTests
	{
		private Mock<IProject> _project;
		private Mock<IProjectsRepository> _repo;
		private Mock<IExternalModulesRepository> _externals;
		private ProjectSpecificVersion _validation;

		[SetUp]
		public void Initialize()
		{
			_project = new Mock<IProject>();
			_repo = new Mock<IProjectsRepository>();
			_externals = new Mock<IExternalModulesRepository>();

			// , _repo.Object, _externals.Object
			_validation = new ProjectSpecificVersion(_project.Object);
		}

		[Test, Ignore]
		public void EmptyTest()
		{
			var result = _validation.Validate();
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}
	}
}
