using System.Linq;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class ProjectSpecificVersionTests : ValidationTestBase
	{
		private ProjectSpecificVersionValidation _projectValidator;

		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_projectValidator = new ProjectSpecificVersionValidation();
		}

		[Test]
		public void EmptyTest()
		{
			var result = _projectValidator.Validate(Context.Object, Project.Object).ToArray();
			Assert.That(result.Count(), Is.EqualTo(1));
			Assert.That(result.Single().ProjectReference, Is.EqualTo(Project.Object));

		}

		[Test]
		public void ParentVersionTest()
		{
			var parentReference = new Mock<IParentReference>();
			parentReference.Setup(p => p.Version).Returns("abc");
			Project.Setup(p => p.Parent).Returns(parentReference.Object);

			var result = _projectValidator.Validate(Context.Object, Project.Object).ToArray();
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Length, Is.EqualTo(1));
			Assert.That(result[0].Severity, Is.EqualTo(ProblemSeverity.ProjectInfo));
		}
	}
}
