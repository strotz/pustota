using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Pustota.Maven.Serialization;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Base.Tests
{
	public class ProjectElement : IChangeTracking
	{
		public bool Changed { get; set; }

		public event OnChangeEventHandler OnChange;

		internal void ReportChange(object sender)
		{
			if (!Changed)
			{
				Changed = true;
				if (OnChange != null)
				{
					OnChange(sender);
				}
			}
		}

		public void ListenChanged(IChangeTracking other)
		{
			other.OnChange += ReportChange;
		}
	}

	public class ObjectsChnagedTests
	{
		[Test]
		public void EventRaiseTest()
		{
			var o = new ProjectElement();
			bool called = false;
			o.OnChange += sender => { called = true; };
			o.ReportChange(this);
			Assert.IsTrue(called);
			Assert.IsTrue(o.Changed);
		}

		[Test]
		public void EventBufferedTest()
		{
			var o = new ProjectElement();
			bool called = false;
			o.Changed = true;
			o.OnChange += sender => { called = true; };
			o.ReportChange(this);
			Assert.IsFalse(called);
		}


		[Test]
		public void ObjectLinkTest()
		{
			var o1 = new ProjectElement();
			var o2 = new ProjectElement();
			o1.ListenChanged(o2);
			o2.ReportChange(this);
			Assert.IsTrue(o1.Changed);
		}
	}

	[TestFixture]
	public class ProjectChangedTests
	{
		private Project _project;

		[SetUp]
		public void Initialize()
		{
			_project = new Project();
			_project.Changed = false;
		}

		[Test]
		public void NotChangedTest()
		{
			Assert.False(_project.Changed);
		}

		[Test]
		public void ChangeArtifactIdTest()
		{
			_project.ArtifactId = "new";
			Assert.True(_project.Changed);
		}
	}
}
