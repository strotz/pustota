using NUnit.Framework;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class PathCalulatorTests
	{
		private PathCalculator _pathCalculator;

		[Test]
		public void PathCalculatorTest()
		{
			_pathCalculator = new PathCalculator(new FileSystemAccess());

			var result = _pathCalculator.CalculateParentPath(new FullPath(@"c:\a\b\c\d\pom.xml"), "../pom.xml");
			Assert.That(result.Value, Is.EqualTo(@"c:\a\b\c\pom.xml"));
		}
	}
}