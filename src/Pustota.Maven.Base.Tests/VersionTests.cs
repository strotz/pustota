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

		[Test]
		public void EqualTest()
		{
			Assert.True(new ComponentVersion("1.2.3") == new ComponentVersion("1.2.3"));
		}

		[Test]
		public void IsDefinedTest()
		{
			var version = new ComponentVersion("a");
			Assert.True(version.IsDefined);
		}
	}
}
