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

		// To Release

		[Test]
		public void ToReleaseFromNullBareTest()
		{
			var version = new ComponentVersion(null).SwitchToRelease(null);
			Assert.That(version.Value, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void ToReleaseFromNullAddPostfixWithDashTest()
		{
			var version = new ComponentVersion(null).SwitchToRelease("-test");
			Assert.That(version.Value, Is.EqualTo("1.0.0-test"));
		}

		[Test]
		public void ToReleaseFromNullAddPostfixNoDashTest()
		{
			var version = new ComponentVersion(null).SwitchToRelease("test");
			Assert.That(version.Value, Is.EqualTo("1.0.0-test"));
		}

		[Test]
		public void ToReleaseFromSnapshotBareTest()
		{
			var version = new ComponentVersion("1.0.0-SNAPSHOT").SwitchToRelease();
			Assert.That(version.Value, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void ToReleaseFromReleaseBareTest() 
		{
			var version = new ComponentVersion("1.0.0").SwitchToRelease();
			Assert.That(version.Value, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void ToReleaseFromReleaseTest()
		{
			var version = new ComponentVersion("1.0.0-RE").SwitchToRelease();
			Assert.That(version.Value, Is.EqualTo("1.0.0-RE"));
		}

		[Test]
		public void AddPostfixReleaseWithSuffixTest()
		{
			var version = new ComponentVersion("1.0.0-RE").SwitchToRelease("rel123");
			Assert.That(version.Value, Is.EqualTo("1.0.0-RE-rel123"));
		}

		// To Snapshot

		[Test]
		public void ToSnapshotFromNullBareTest()
		{
			var version = new ComponentVersion(null).SwitchToSnapshotWithVersionIncrement();
			Assert.That(version.Value, Is.EqualTo("1.0.0-SNAPSHOT"));
		}

		[Test]
		public void ToSnapshotFromReleaseBareTest()
		{
			var version = new ComponentVersion("1.0.0").SwitchToSnapshotWithVersionIncrement();
			Assert.That(version.Value, Is.EqualTo("1.0.1-SNAPSHOT")); // TODO: Add ability to manage what version to increment
		}

		[Test]
		public void ToSnapshotFromReleaseWithSuffixTest()
		{
			var version = new ComponentVersion("1.0.0-RE").SwitchToSnapshotWithVersionIncrement();
			Assert.That(version.Value, Is.EqualTo("1.0.1-RE-SNAPSHOT"));
		}

		[Test]
		public void ToSnapshotFromSnapshotTest()
		{
			var version = new ComponentVersion("1.0.0-SNAPSHOT").SwitchToSnapshotWithVersionIncrement();
			Assert.That(version.Value, Is.EqualTo("1.0.0-SNAPSHOT"));
		}

	}
}
