using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class VersionTests
	{

		[Test]
		public void EqualTest()
		{
			Assert.True(new Version("1.2.3") == new Version("1.2.3"));
		}
	}
}
