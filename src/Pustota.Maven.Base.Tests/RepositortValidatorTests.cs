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

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class RepositortValidatorTests
	{
		private RepositoryValidator _validator;

		private Mock<IProjectValidationFactory> _factory;
		private Mock<IProjectsRepository> _repo;
		private Mock<IExternalModulesRepository> _externals;
		private ValidationContext _context;

		[SetUp]
		public void Initialize()
		{
			_factory = new Mock<IProjectValidationFactory>();
			_repo = new Mock<IProjectsRepository>();
			_externals = new Mock<IExternalModulesRepository>();
			_validator = new RepositoryValidator(_factory.Object);

			_context = new ValidationContext
			{
				Repository = _repo.Object,
				ExternalModules = _externals.Object
			};
		}

		[TearDown]
		public void Shutdown()
		{
		}

		[Test]
		public void EmptyTest()
		{
			var result = _validator.Validate(_context);
			Assert.IsNotNull(result);
			Assert.That(result, Is.Empty);
		}

		[Test]
		public void SingleTest()
		{
			var project = new Mock<IProject>();
			_repo.Setup(r => r.AllProjects).Returns(new[] {project.Object});

			var problem = new ValidationProblem
			{
				Severity = ProblemSeverity.ProjectWarning
			};

			var validator = new Mock<IProjectValidator>();
			validator.Setup(v => v.Validate(It.IsAny<ValidationContext>(), project.Object)).Returns(new[] { problem });

			_factory.Setup(f => f.BuildProjectValidationSequence()).Returns(new[] { validator.Object });

			var result = _validator.Validate(_context);
			Assert.IsNotNull(result);
			Assert.That(result.Single(), Is.EqualTo(problem));
		}
	}
}
