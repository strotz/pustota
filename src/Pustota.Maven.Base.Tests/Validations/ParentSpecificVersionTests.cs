using System.Linq;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	[TestFixture]
	public class ParentSpecificVersionTests : ValidationTestBase
	{
		private ParentSpecificVersionValidation _projectValidator;

		private Mock<IParentReference> _parent;
		
		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_parent = new Mock<IParentReference>();
			_projectValidator = new ParentSpecificVersionValidation();
		}

		[Test]
		public void EmptyTest()
		{
			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public void EmptyParentTest()
		{
			Project.Setup(p => p.Parent).Returns(_parent.Object);

			var result = _projectValidator.Validate(Context.Object, Project.Object).ToList();
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(1));
			Assert.That(result.Single().Severity, Is.EqualTo(ProblemSeverity.ProjectFatal));
			Assert.That(result.Single().ProjectReference, Is.EqualTo(Project.Object));
		}

		[Test]
		public void ParentWithVersionTest()
		{
			Project.Setup(p => p.Parent).Returns(_parent.Object);
			_parent.Setup(p => p.Version).Returns("abc".ToVersion());

			var result = _projectValidator.Validate(Context.Object, Project.Object).ToList();
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}
	}
}
