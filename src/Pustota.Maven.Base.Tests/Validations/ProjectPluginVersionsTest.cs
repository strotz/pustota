using System;
using System.Linq;
using System.Runtime.InteropServices;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Externals;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	[TestFixture]
	public class ProjectPluginVersionsTest
	{
		private Mock<IProject> _project;
		private Mock<IProjectsRepository> _repo;
		private Mock<IExternalModulesRepository> _externals;
		private ProjectPluginVersionsValidation _validation;

		[SetUp]
		public void Initialize()
		{
			_project = new Mock<IProject>();
			_repo = new Mock<IProjectsRepository>();
			_externals = new Mock<IExternalModulesRepository>();

			_validation = new ProjectPluginVersionsValidation(_project.Object, _repo.Object, _externals.Object);

		}

		[Test]
		public void EmptyTest()
		{
			var result = _validation.Validate();
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test, Ignore]
		public void UndefinedPluginTest()
		{
			throw new NotImplementedException();
		}
	}
}