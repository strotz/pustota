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
			_parentReference.Setup(pr => pr.ArtifactId).Returns("parentId");
			_parentReference.Setup(pr => pr.Version).Returns("parentVersion1");
			Project.Setup(p => p.Parent).Returns(_parentReference.Object);

			_parent = new Mock<IProject>();
			_parent.Setup(pr => pr.ArtifactId).Returns("parentId");

			_projectValidator = new ParentReferenceExistValidation();
		}

		[Test]
		public void EmptyTest()
		{
			Project.Setup(p => p.Parent).Returns((IParentReference)null);

			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ProjectHasNoMatchedParentTest()
		{
			IProject foundParent = null;
			Context.Setup(c => c.TryGetParentByPath(Project.Object, out foundParent)).Returns(false);

			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);

			var problem = result.Single();
			Assert.That(((ValidationProblem)problem).ProblemCode, Is.EqualTo("parentmissing"));
		}

		[Test]
		public void ProjectHasNoMatchedParentButExternalTest()
		{
			var external = new Mock<IProjectReference>();
			external.Setup(pr => pr.ArtifactId).Returns("parentId");
			external.Setup(pr => pr.Version).Returns("parentVersion1");

			IProject foundParent = null;
			Context.Setup(c => c.TryGetParentByPath(Project.Object, out foundParent)).Returns(false);
			Context.Setup(c => c.AllAvailableProjectReferences).Returns(new IProjectReference[] {external.Object});
			ExternalModules.Setup(c => c.Contains(_parentReference.Object)).Returns(true);

			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ProjectHasNoMatchedAndPathParentButExternalTest()
		{
			var external = new Mock<IProjectReference>();
			external.Setup(pr => pr.ArtifactId).Returns("parentId");
			external.Setup(pr => pr.Version).Returns("parentVersion1");
			
			_parentReference.Setup(pr => pr.RelativePath).Returns("path");

			IProject foundParent = null;
			Context.Setup(c => c.TryGetParentByPath(Project.Object, out foundParent)).Returns(false);
			Context.Setup(c => c.AllAvailableProjectReferences).Returns(new IProjectReference[] { external.Object });
			ExternalModules.Setup(c => c.Contains(_parentReference.Object)).Returns(true);

			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);

			var problem = result.Single();
			Assert.That(((ValidationProblem)problem).ProblemCode, Is.EqualTo("parentpath"));
		}


		[Test]
		public void ProjectHasMatchedParentTest()
		{
			_parent.Setup(pr => pr.Version).Returns("parentVersion1");

			IProject foundParent = _parent.Object;
			Context.Setup(c => c.TryGetParentByPath(Project.Object, out foundParent)).Returns(true);

			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ProjectHasMatchedParentThatInheritsItsVersionTest() // to use inherited version 
		{
			_parent.Setup(pr => pr.Version).Returns((string)null);

			var grandReference = new Mock<IParentReference>();
			grandReference.Setup(pr => pr.ArtifactId).Returns("grandId");
			grandReference.Setup(g => g.Version).Returns("parentVersion1");
			_parent.Setup(pr => pr.Parent).Returns(grandReference.Object);

			IProject foundParent = _parent.Object;
			Context.Setup(c => c.TryGetParentByPath(Project.Object, out foundParent)).Returns(true);

			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public void ProjectHasSemiMatchedParentTest()
		{
			_parent.Setup(pr => pr.Version).Returns("parentVersion2");

			IProject foundParent = _parent.Object;
			Context.Setup(c => c.TryGetParentByPath(Project.Object, out foundParent)).Returns(true);

			var result = _projectValidator.Validate(Context.Object, Project.Object).ToArray();
			Assert.That(result.Single().Severity, Is.EqualTo(ProblemSeverity.ProjectWarning));
			Assert.That(result.Single().ProjectReference, Is.EqualTo(Project.Object));
		}

		[Test]
		public void NoProjectInPathButRepoHasGoodParentTest()
		{
			_parent.Setup(pr => pr.Version).Returns("parentVersion1");

			IProject foundParentByPath = null;
			Context.Setup(c => c.TryGetParentByPath(Project.Object, out foundParentByPath)).Returns(false);

			IProject foundParentByRef = _parent.Object;
			Context.Setup(c => c.TryGetProject(_parentReference.Object, out foundParentByRef, true)).Returns(true);

			var result = _projectValidator.Validate(Context.Object, Project.Object).ToArray();
			Assert.That(result.Single().Severity, Is.EqualTo(ProblemSeverity.ProjectWarning));
			Assert.That(result.Single().ProjectReference, Is.EqualTo(Project.Object));
		}

		[Test]
		public void NoProjectInPathButRepoHasSemiGoodParentTest()
		{
			_parent.Setup(pr => pr.Version).Returns("parentVersion1");

			IProject foundParentByPath = null;
			Context.Setup(c => c.TryGetParentByPath(Project.Object, out foundParentByPath)).Returns(false);

			IProject foundParentByRef = _parent.Object;
			Context.Setup(c => c.TryGetProject(_parentReference.Object, out foundParentByRef, false)).Returns(true);

			var result = _projectValidator.Validate(Context.Object, Project.Object).ToArray();
			Assert.That(result.Single().Severity, Is.EqualTo(ProblemSeverity.ProjectWarning));
			Assert.That(result.Single().ProjectReference, Is.EqualTo(Project.Object));
		}


	}
}
