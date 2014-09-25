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
		private Mock<IParentReference> _parentReference;
		private Mock<IProject> _parent;


		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_parentReference = new Mock<IParentReference>();
			_parent = new Mock<IProject>();

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
		public void ProjectHasMatchedParentTest()
		{
			_parentReference.Setup(pr => pr.ArtifactId).Returns("parentId");
			Project.Setup(p => p.Parent).Returns(_parentReference.Object);

			_parent.Setup(pr => pr.ArtifactId).Returns("parentId");

			IProject foundParent = _parent.Object;
			Context.Setup(c => c.TryGetParentByPath(Project.Object, out foundParent)).Returns(true);

			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ProjectHasSemiMatchedParentTest()
		{
			_parentReference.Setup(pr => pr.ArtifactId).Returns("parentId");
			_parentReference.Setup(pr => pr.Version).Returns("parentVersion1");
			Project.Setup(p => p.Parent).Returns(_parentReference.Object);

			_parent.Setup(pr => pr.ArtifactId).Returns("parentId");
			_parent.Setup(pr => pr.Version).Returns("parentVersion2");

			IProject foundParent = _parent.Object;
			Context.Setup(c => c.TryGetParentByPath(Project.Object, out foundParent)).Returns(true);

			var result = _projectValidator.Validate(Context.Object, Project.Object).ToArray();
			Assert.That(result.Single().Severity, Is.EqualTo(ProblemSeverity.ProjectWarning));
		}

	}
}
