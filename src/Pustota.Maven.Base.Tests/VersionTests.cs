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
        public void ToReleaseVersionFromUndefinedBareTest()
        {
            var version = ComponentVersion.Undefined;
            Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease(new ComponentVersion("1.0.0")); });
        }

        [Test]
		public void ToReleaseFromUndefinedAddPostfixWithDashTest()
		{
			var version = ComponentVersion.Undefined;
			Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease(postfix: "-test"); });
		}

		[Test]
		public void ToReleaseFromNullAddPostfixNoDashTest()
		{
			var version = ComponentVersion.Undefined;
			Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease(postfix: "test"); });
		}

		[Test]
		public void ToReleaseFromSnapshotBareTest()
		{
			var version = new ComponentVersion("1.0.0-SNAPSHOT").SwitchSnapshotToRelease();
			Assert.That(version.Value, Is.EqualTo("1.0.0"));
		}

		[Test]
		public void ToReleaseFromSnapshotWithBuildTest()
		{
			var version = new ComponentVersion("1.0.0-SNAPSHOT").SwitchSnapshotToRelease(build: 66);
			Assert.That(version.Value, Is.EqualTo("1.0.0.66"));
		}

		[Test]
		public void ToReleaseFromSnapshotWithBuildAndSuffixTest()
		{
			var version = new ComponentVersion("1.0.0-SNAPSHOT").SwitchSnapshotToRelease(build: 66, postfix: "zzz");
			Assert.That(version.Value, Is.EqualTo("1.0.0.66-zzz"));
		}

        [Test]
        public void ToReleaseFromSnapshotWithVersionTest()
        {
            var version = new ComponentVersion("1.0.0-SNAPSHOT").SwitchSnapshotToRelease("1.0.0.66".ToVersion());
            Assert.That(version.Value, Is.EqualTo("1.0.0.66"));
        }

        [Test]
        public void ToReleaseFromSnapshotNoCompatibleTest()
        {
            var version = new ComponentVersion("1.0.0-SNAPSHOT");
            Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease("1.1.0.8".ToVersion());});
        }

        [Test]
        public void ToUndefinedFromSnapshotTest()
        {
            var version = new ComponentVersion("1.0.0-SNAPSHOT");
            Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease(ComponentVersion.Undefined); });
        }

        [Test]
        public void ToSnapshotFromSnapshotVersionTest()
        {
            var version = new ComponentVersion("1.0.0-SNAPSHOT");
            Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease("1.0.0-SNAPSHOT".ToVersion()); });
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
			Assert.Throws<InvalidOperationException>(delegate { version.SwitchSnapshotToRelease(postfix: "abc"); });
		}

		// To Snapshot

		[Test]
		public void ToSnapshotFromNullBareTest()
		{
			var version = new ComponentVersion(null);
			Assert.Throws<InvalidOperationException>(delegate { version.Operations().ToSnapshotWithVersionIncrement(); });
		}

		[Test]
		public void ToSnapshotFromReleaseBareTest()
		{
			var version = new ComponentVersion("1.0.0").Operations().ToSnapshotWithVersionIncrement();
			Assert.That(version.Value, Is.EqualTo("1.0.1-SNAPSHOT")); 
		}

		[Test]
		public void ToSnapshotFromReleaseWithSuffixTest()
		{
			var version = new ComponentVersion("1.0.0-RE").Operations().ToSnapshotWithVersionIncrement();
			Assert.That(version.Value, Is.EqualTo("1.0.1-RE-SNAPSHOT"));
		}

		[Test]
		public void ToSnapshotFromSnapshotTest()
		{
			var version = new ComponentVersion("1.0.0-SNAPSHOT");
			Assert.Throws<InvalidOperationException>(delegate { version.Operations().ToSnapshotWithVersionIncrement(); });
		}

		// To Snapshot with position

		[Test]
		public void ToSnapshotFromNullWithPositionTest()
		{
			var version = new ComponentVersion(null);
			Assert.Throws<InvalidOperationException>(delegate { version.Operations().ToSnapshotWithVersionIncrement(1); });
		}

		[Test]
		public void ToSnapshotFromReleaseWithFirstPositionTest()
		{
			var version = new ComponentVersion("1.0.0").Operations().ToSnapshotWithVersionIncrement(1);
			Assert.That(version.Value, Is.EqualTo("1.1.0-SNAPSHOT")); 
		}

		[Test]
		public void ToSnapshotFromReleaseWithZeroPositionTest()
		{
			var version = new ComponentVersion("1.0.0").Operations().ToSnapshotWithVersionIncrement(0);
			Assert.That(version.Value, Is.EqualTo("2.0.0-SNAPSHOT"));
		}

		[Test]
		public void ToSnapshotFromReleaseWithSuffixAndPositionTest()
		{
			var version = new ComponentVersion("1.0.0-RE").Operations().ToSnapshotWithVersionIncrement(1);
			Assert.That(version.Value, Is.EqualTo("1.1.0-RE-SNAPSHOT"));
		}

		[Test]
		public void ToSnapshotFromReleaseWithWrongPositionTest()
		{
			var version = new ComponentVersion("1.0.0");
			Assert.Throws<InvalidOperationException>(delegate { version.Operations().ToSnapshotWithVersionIncrement(4); });
		}


	}
}
