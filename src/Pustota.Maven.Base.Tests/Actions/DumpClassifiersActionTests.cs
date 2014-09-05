using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Actions;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Base.Tests.Actions
{
	public class DumpClassifiersActionTests
	{
		[Test]
		public void TwoProjectsDependencyTest()
		{
			var projectA = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0-SNAPSHOT",
			};

			var projectB = new Project
			{
				GroupId = "group",
				ArtifactId = "b",
				Version = "1.0.1-SNAPSHOT",
			};

			projectB.Dependencies.Add(
				new Dependency
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0-SNAPSHOT",
					Classifier = "${test}"
				}
				);

			projectB.Dependencies.Add(
				new Dependency
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0-SNAPSHOT",
					Classifier = "something on front ${test}"
				}
				);

			projectB.Dependencies.Add(
				new Dependency
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0-SNAPSHOT",
					Classifier = "${test} something on back"
				}
				);

			projectB.Dependencies.Add(
				new Dependency
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0-SNAPSHOT",
					Classifier = "${test}"
				}
				);


			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new DumpClassifiersAction(repo.Object);

			var result = action.Execute();

			Assert.That(result.Count(), Is.EqualTo(3));
		}

	}
}
