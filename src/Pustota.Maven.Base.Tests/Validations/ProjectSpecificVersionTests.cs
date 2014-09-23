using System.Linq;
using NUnit.Framework;
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

		[Test, Ignore]
		public void EmptyTest()
		{
			var result = _projectValidator.Validate(Context, Project.Object);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}
	}
}
