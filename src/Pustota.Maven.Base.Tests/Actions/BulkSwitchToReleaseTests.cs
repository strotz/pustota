using System.Linq;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Actions;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Base.Tests.Actions
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

		[Test]
		public void SingleProjectTest()
		{
			var project = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0-SNAPSHOT"
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] {project});

			var action = new BulkSwitchToReleaseAction(repo.Object, "-test");

			action.Execute();

			Assert.That(project.Version.Value, Is.EqualTo("1.0.0-test"));
			Assert.False(project.ReferenceOperations().IsSnapshot);
		}

		[Test]
		public void TwoProjectsTest()
		{
			var projectA = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0-SNAPSHOT"
			};

			var projectB = new Project
			{
				GroupId = "group",
				ArtifactId = "b",
				Version = "1.0.1-SNAPSHOT"
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new BulkSwitchToReleaseAction(repo.Object, "-test");

			action.Execute();

			Assert.That(projectA.Version.Value, Is.EqualTo("1.0.0-test"));
			Assert.False(projectA.ReferenceOperations().IsSnapshot);

			Assert.That(projectB.Version.Value, Is.EqualTo("1.0.1-test"));
			Assert.False(projectB.ReferenceOperations().IsSnapshot);
		}

		[Test]
		public void TwoProjectsParentTest()
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
				Parent = new ParentReference{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0-SNAPSHOT",
				},
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new BulkSwitchToReleaseAction(repo.Object, "-test");

			action.Execute();

			Assert.That(projectB.Parent.Version, Is.EqualTo(new Version("1.0.0-test")));
			Assert.False(projectB.Parent.ReferenceOperations().IsSnapshot);
		}

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
				}
			);

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new BulkSwitchToReleaseAction(repo.Object, "-test");

			action.Execute();

			var dependency = projectB.Dependencies.Single();
			Assert.That(dependency.Version.Value, Is.EqualTo("1.0.0-test"));
			Assert.False(dependency.ReferenceOperations().IsSnapshot);
		}

		[Test]
		public void TwoProjectsPluginTest()
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

			projectB.Plugins.Add(
				new Plugin
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0-SNAPSHOT",
				}
			);

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new BulkSwitchToReleaseAction(repo.Object, "-test");

			action.Execute();

			var plugin = projectB.Plugins.Single();
			Assert.That(plugin.Version.Value, Is.EqualTo("1.0.0-test"));
			Assert.False(plugin.ReferenceOperations().IsSnapshot);
		}

		[Test]
		public void ExternalReferenceTest()
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
				Parent = new ParentReference
				{
					GroupId = "group",
					ArtifactId = "x",
					Version = "1.0.0-SNAPSHOT",
				},
			};

			projectB.Plugins.Add(
				new Plugin
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0-SNAPSHOT",
				}
			);

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new BulkSwitchToReleaseAction(repo.Object, "-test");

			action.Execute();

			Assert.That(projectB.Parent.Version.Value, Is.EqualTo("1.0.0-SNAPSHOT"));
			Assert.True(projectB.Parent.ReferenceOperations().IsSnapshot); // REVIEW: should we fail, when switch to release and parent is snapshot?
		}

	}
}
