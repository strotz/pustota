using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Actions;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class BulkSwitchToReleaseTests
	{
		[Test]
		public void EmptyTest()
		{
			var repo = new Mock<IProjectsRepository>();
			var action = new BulkSwitchToReleaseAction(repo.Object, "test");

			action.Execute();
		}
	}
}
