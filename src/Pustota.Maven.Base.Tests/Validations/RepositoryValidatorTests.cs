using System.Linq;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	[TestFixture]
	public class RepositoryValidatorTests
	{
		private RepositoryValidator _validator;

		private Mock<IRepositoryValidationFactory> _factory;
		private Mock<IExecutionContext> _context;

		[SetUp]
		public void Initialize()
		{
			_factory = new Mock<IRepositoryValidationFactory>();
			_validator = new RepositoryValidator(_factory.Object);

			_context = new Mock<IExecutionContext>();
		}

		[TearDown]
		public void Shutdown()
		{
		}

		[Test]
		public void EmptyTest()
		{
			var result = _validator.Validate(_context.Object);
			Assert.IsNotNull(result);
			Assert.That(result, Is.Empty);
		}

		[Test]
		public void SingleTest()
		{
			var project = new Mock<IProject>();
			_context.Setup(r => r.AllProjects).Returns(new[] {project.Object});

			var problem = new ValidationProblem("a")
			{
				Severity = ProblemSeverity.ProjectWarning
			};

			var validator = new Mock<IProjectValidator>();
			validator.Setup(v => v.Validate(It.IsAny<IExecutionContext>(), project.Object)).Returns(new[] { problem });

			_factory.Setup(f => f.BuildProjectValidationSequence()).Returns(new[] { validator.Object });

			var result = _validator.Validate(_context.Object);
			Assert.IsNotNull(result);
			Assert.That(result.Single(), Is.EqualTo(problem));
		}

		[Test]
		public void BreakOnFatalTest()
		{
			var project1 = new Mock<IProject>();
			var project2 = new Mock<IProject>();
			_context.Setup(r => r.AllProjects).Returns(new[] { project1.Object, project2.Object });

			var fatal = new ValidationProblem("a") { Severity = ProblemSeverity.ProjectFatal };
			var warning = new ValidationProblem("a") { Severity = ProblemSeverity.ProjectWarning };

			var v1 = new Mock<IProjectValidator>();
			v1.Setup(v => v.Validate(It.IsAny<IExecutionContext>(), project1.Object)).Returns(new[] { fatal });

			var v2 = new Mock<IProjectValidator>();
			v2.Setup(v => v.Validate(It.IsAny<IExecutionContext>(), project1.Object)).Returns(new[] { warning });

			_factory.Setup(f => f.BuildProjectValidationSequence()).Returns(new[] { v1.Object, v2.Object });

			var result = _validator.Validate(_context.Object);
			Assert.IsNotNull(result);
			Assert.That(result.Single(), Is.EqualTo(fatal));

			v1.Verify(v => v.Validate(It.IsAny<IExecutionContext>(), project1.Object), Times.Once());
			v1.Verify(v => v.Validate(It.IsAny<IExecutionContext>(), project2.Object), Times.Once());

			v2.Verify(v => v.Validate(It.IsAny<IExecutionContext>(), project1.Object), Times.Never());
			v2.Verify(v => v.Validate(It.IsAny<IExecutionContext>(), project2.Object), Times.Once());
		}
	}
}
