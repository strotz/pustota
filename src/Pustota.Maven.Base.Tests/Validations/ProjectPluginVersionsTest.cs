using System;
using System.Linq;
using NUnit.Framework;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	[TestFixture]
	public class ProjectPluginVersionsTest : ValidationTestBase
	{
		private ProjectPluginVersionsValidation _projectValidator;
		
		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_projectValidator = new ProjectPluginVersionsValidation();
		}

		[Test]
		public void EmptyTest()
		{
			var result = _projectValidator.Validate(Context, Project.Object);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test, Ignore]
		public void UndefinedPluginTest()
		{
			throw new NotImplementedException();
		}
	}
}