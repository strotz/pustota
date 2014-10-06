using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Pustota.Maven.Models;
namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class VersionTests
	{	
		// Equal

		[Test]
		public void EqualTest()
		{
			Assert.True(new ComponentVersion("1.2.3") == new ComponentVersion("1.2.3"));
		}

		[Test]
		public void NullableVerionEqualTest()
		{
			Assert.True(new ComponentVersion(null) == new ComponentVersion(null));
			Assert.True(new ComponentVersion(null) != new ComponentVersion("1.2.3"));
			Assert.True(new ComponentVersion("1.2.3") != new ComponentVersion(null));
		}

		// Add postfix

		[Test]
		public void AddPostfixEmptyTest()
		{
			var version = new ComponentVersion(null);
			version.AddPostfix(null);
			Assert.That(version.Value, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void AddPostfixWithDashTest()
		{
			var version = new ComponentVersion(null);
			version.AddPostfix("-test");
			Assert.That(version.Value, Is.EqualTo("1.0.0-test"));
		}

		[Test]
		public void AddPostfixNoDashTest()
		{
			var version = new ComponentVersion(null);
			version.AddPostfix("test");

			Assert.That(version.Value, Is.EqualTo("1.0.0-test"));
		}

		[Test]
		public void AddPostfixReleaseWithSuffixTest()
		{
			var version = new ComponentVersion("1.0.0-RE");
			version.AddPostfix("rel123");
			Assert.That(version.Value, Is.EqualTo("1.0.0-RE-rel123"));
		}

		// Query

		[Test]
		public void IsDefinedTest()
		{
			var version = new ComponentVersion("a");
			Assert.True(version.IsDefined);
		}

		[Test]
		public void IsNotDefinedTest()
		{
			var version = new ComponentVersion(string.Empty);
			Assert.True(!version.IsDefined);
		}

		[Test]
		public void IsSnapshotPositiveTest()
		{
			var version = new ComponentVersion("A-SNAPSHOT");
			Assert.True(version.IsSnapshot);
		}

		[Test]
		public void EmptyIsNotSnapshotTest()
		{
			Assert.False(new ComponentVersion(null).IsSnapshot);
		}

		[Test]
		public void ToReleaseFromNullBareTest()
		{
			var version = new ComponentVersion(null);
			version.SwitchToRelease();
			Assert.That(version.Value, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void ToReleaseFromSnapshotBareTest()
		{
			var version = new ComponentVersion("1.0.0-SNAPSHOT");
			version.SwitchToRelease();
			Assert.That(version.Value, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void ToReleaseFromReleaseBareTest() 
		{
			var version = new ComponentVersion("1.0.0");
			version.SwitchToRelease();
			Assert.That(version.Value, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void ToReleaseFromReleaseTest()
		{
			var version = new ComponentVersion("1.0.0-RE");
			version.SwitchToRelease();
			Assert.That(version.Value, Is.EqualTo("1.0.0-RE"));
		}

		[Test]
		public void ToSnapshotFromNullBareTest()
		{
			var version = new ComponentVersion(null);
			version.SwitchToSnapshotWithVersionIncrement();
			Assert.That(version.Value, Is.EqualTo("1.0.0-SNAPSHOT"));
		}

		[Test]
		public void ToSnapshotFromReleaseBareTest()
		{
			var version = new ComponentVersion("1.0.0");
			version.SwitchToSnapshotWithVersionIncrement();
			Assert.That(version.Value, Is.EqualTo("1.0.1-SNAPSHOT")); // TODO: Add ability to manage what version to increment
		}

		[Test]
		public void ToSnapshotFromReleaseWithSuffixTest()
		{
			var version = new ComponentVersion("1.0.0-RE");
			version.SwitchToSnapshotWithVersionIncrement();
			Assert.Fail();
			Assert.That(version.Value, Is.EqualTo("1.0.1-SNAPSHOT"));
		}

		[Test]
		public void ToSnapshotFromSnapshotTest()
		{
			var version = new ComponentVersion("1.0.0-SNAPSHOT");
			version.SwitchToSnapshotWithVersionIncrement();
			Assert.That(version.Value, Is.EqualTo("1.0.0-SNAPSHOT"));
		}

	}
}
