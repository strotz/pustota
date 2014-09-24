using System.Linq;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	[TestFixture]
	public class ParentReferenceExistTests : ValidationTestBase
	{
		private ParentReferenceExistValidation _projectValidator;
		private Mock<IParentReference> _parent;

		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_parent = new Mock<IParentReference>();

			_projectValidator = new ParentReferenceExistValidation();
		}

		[Test]
		public void EmptyTest()
		{
			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ProjectHasParentTest()
		{
			Project.Setup(p => p.Parent).Returns(_parent.Object);

			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.Not.EqualTo(0));
		}
	}
}
