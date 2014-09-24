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

		private Mock<IParentReference> _parent;

		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_parent = new Mock<IParentReference>();
			_projectValidator = new ProjectSpecificVersionValidation();
		}

		[Test]
		public void EmptyTest()
		{
			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(1));
		}

		[Test]
		public void ProjectHasVersionTest()
		{
			Project.Setup(p => p.Version).Returns("abc");

			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ParentHasVersionTest()
		{
			Project.Setup(p => p.Parent).Returns(_parent.Object);
			_parent.Setup(p => p.Version).Returns("abc");

			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}
	}
}
