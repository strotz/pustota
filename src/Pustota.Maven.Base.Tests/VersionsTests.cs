using NUnit.Framework;

namespace Pustota.Maven.Base.Tests
{
	public class VersionsTests
	{
		[Test]
		public void AddPostfixEmptyTest()
		{
			string version = null; 
			string postfix = null;

			Assert.That(VersionOperations.AddPostfix(version, postfix), Is.EqualTo("1.0.0"));
		}

		[Test]
		public void AddPostfixWithDashTest()
		{
			string version = null;
			string postfix = "-test";

			Assert.That(VersionOperations.AddPostfix(version, postfix), Is.EqualTo("1.0.0-test"));
		}

		[Test]
		public void AddPostfixNoDashTest()
		{
			string version = null;
			string postfix = "test";

			Assert.That(VersionOperations.AddPostfix(version, postfix), Is.EqualTo("1.0.0-test"));
		}
	}
}
