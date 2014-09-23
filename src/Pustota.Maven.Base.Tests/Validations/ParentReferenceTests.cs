using System.Linq;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	[TestFixture]
	public class ParentReferenceTests : ValidationTestBase
	{
		private ParentReferenceValidation _projectValidator;

		private Mock<IParentReference> _parent;

		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_parent = new Mock<IParentReference>();
			_projectValidator = new ParentReferenceValidation();
		}

		[Test]
		public void EmptyTest()
		{
			var result = _projectValidator.Validate(Context, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public void EmptyParentTest()
		{
			Project.Setup(p => p.Parent).Returns(_parent.Object);

			var result = _projectValidator.Validate(Context, Project.Object).ToList();
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(1));
			Assert.That(result.Single().Severity, Is.EqualTo(ProblemSeverity.ProjectFatal));
		}

		[Test]
		public void ParentWithArtifactTest()
		{
			Project.Setup(p => p.Parent).Returns(_parent.Object);
			_parent.Setup(p => p.ArtifactId).Returns("abc");

			var result = _projectValidator.Validate(Context, Project.Object).ToList();
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}
	}
}