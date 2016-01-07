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

		[Test]
		public void UndefinedVersionIsNullTest()
		{
			Assert.That(ComponentVersion.Undefined, Is.EqualTo(new ComponentVersion(null)));
		} 

		// Query

		[Test]
		public void IsDefinedTest()
		{
			var version = new ComponentVersion("a");
			Assert.True(version.IsDefined);
		}

		[Test]
		public void EmptyStringIsNotDefinedTest()
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
		public void UndefinedIsNotSnapshotTest()
		{
			Assert.False(ComponentVersion.Undefined.IsSnapshot);
		}

		[Test]
		public void UndefinedIsNotReleaseTest()
		{
			Assert.False(ComponentVersion.Undefined.IsRelease);
		}

		[Test]
		public void SnapshotIsNotReleaseTest()
		{
			Assert.False(new ComponentVersion("1.2.3-SNAPSHOT").IsRelease);
		}

		[Test]
		public void VersionIsReleaseTest()
		{
			Assert.True(new ComponentVersion("1.2.3").IsRelease);
		}
		// To Release

		[Test]
		public void ToReleaseFromUndefinedBareTest()
		{
			var version = ComponentVersion.Undefined;
			Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease(); });
		}

		[Test]
		public void ToReleaseFromUndefinedAddPostfixWithDashTest()
		{
			var version = ComponentVersion.Undefined;
			Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease("-test"); });
		}

		[Test]
		public void ToReleaseFromNullAddPostfixNoDashTest()
		{
			var version = ComponentVersion.Undefined;
			Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease("test"); });
		}

		[Test]
		public void ToReleaseFromSnapshotBareTest()
		{
			var version = new ComponentVersion("1.0.0-SNAPSHOT").SwitchSnapshotToRelease();
			Assert.That(version.Value, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void ToReleaseFromReleaseBareTest() 
		{
			var version = new ComponentVersion("1.0.0");
			Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease(); });

		}

		[Test]
		public void ToReleaseFromReleaseTest()
		{
			var version = new ComponentVersion("1.0.0-RE");
			Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease(); });
		}

		[Test]
		public void AddPostfixReleaseWithSuffixTest()
		{
			var version = new ComponentVersion("1.0.0-RE");
			Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease("abc"); });
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
