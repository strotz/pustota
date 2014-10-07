using NUnit.Framework;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class DuplicatedExternalModulesValidationTests : ValidationTestBase
	{
		private DuplicatedExternalModulesValidation _validator;

		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_validator = new DuplicatedExternalModulesValidation();
		}

		[Test]
		public void EmptyTest()
		{
			_validator.Validate(Context.Object);
		}
	}
}