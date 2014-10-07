using NUnit.Framework;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class UselessExternalModulesValidationTests : ValidationTestBase
	{
		private UselessExternalModulesValidation _validator;

		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_validator = new UselessExternalModulesValidation();
		}

		[Test]
		public void EmptyTest()
		{
			_validator.Validate(Context.Object);
		}
	}
}