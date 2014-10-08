using NUnit.Framework;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class PathCalulatorTests
	{
		private PathCalculator _pathCalculator;

		[SetUp]
		public void Initialize()
		{
			_pathCalculator = new PathCalculator(new FileSystemAccess());
		}

		[Test]
		public void ParentPathCalculatorTest()
		{
			var result = _pathCalculator.CalculateParentPath(new FullPath(@"c:\a\b\c\d\pom.xml"), "../pom.xml");
			Assert.That(result.Value, Is.EqualTo(@"c:\a\b\c\pom.xml"));
		}

		[Test]
		public void ModulePathCalculatorTest()
		{
			var result = _pathCalculator.CalculateModulePath(new FullPath(@"c:\a\b\pom.xml"), @"c\d");
			Assert.That(result.Value, Is.EqualTo(@"c:\a\b\c\d\pom.xml"));
		}

	}
}