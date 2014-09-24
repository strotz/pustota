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

			Context.Setup(c => c.GetResolvedData(Project.Object)).Returns(ResolvedProjectData.Object);

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
		public void ResolvedDataHasVersionTest()
		{
			ResolvedProjectData.Setup(p => p.Version).Returns("abc");

			var result = _projectValidator.Validate(Context.Object, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}
	}
}
