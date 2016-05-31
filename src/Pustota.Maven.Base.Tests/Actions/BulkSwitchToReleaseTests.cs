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
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { project });

			var action = new BulkSwitchToReleaseAction(repo.Object, "-test");

			action.Execute();

			Assert.That(project.Version.Value, Is.EqualTo("1.0.0-test"));
		}

		[Test]
		public void SingleProjectWithBuildTest()
		{
			var project = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0-SNAPSHOT"
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { project });

			var action = new BulkSwitchToReleaseAction(repo.Object, "-test", 123);

			action.Execute();

			Assert.That(project.Version.Value, Is.EqualTo("1.0.0.123-test"));
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
			Assert.That(projectB.Version.Value, Is.EqualTo("1.0.1-test"));
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
				Parent = new ParentReference
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0-SNAPSHOT",
				},
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new BulkSwitchToReleaseAction(repo.Object, "-test");

			action.Execute();

			Assert.That(projectB.Parent.Version, Is.EqualTo(new ComponentVersion("1.0.0-test")));
		}

		[Test]
		public void ThreeProjectsCascadeParentTest()
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
				Parent = new ParentReference
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0-SNAPSHOT",
				},
			};

			var projectC = new Project
			{
				GroupId = "group",
				ArtifactId = "c",
				Parent = new ParentReference
				{
					GroupId = "group",
					ArtifactId = "b",
					Version = "1.0.0-SNAPSHOT",
				},
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB, projectC });

			var action = new BulkSwitchToReleaseAction(repo.Object, "-test");

			action.Execute();

			Assert.That(projectB.Parent.Version, Is.EqualTo(new ComponentVersion("1.0.0-test")));
			Assert.That(projectB.Version.IsDefined, Is.False);

			Assert.That(projectC.Parent.Version, Is.EqualTo(new ComponentVersion("1.0.0-test")), "cascade parent version");
			Assert.That(projectC.Version.IsDefined, Is.False);
		}

		[Test]
		public void ThreeProjectsCascadeGrouplessParentTest()
		{
			var projectA = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0-SNAPSHOT",
			};

			var projectB = new Project
			{
				ArtifactId = "b",
				Parent = new ParentReference
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0-SNAPSHOT",
				},
			};

			var projectC = new Project
			{
				ArtifactId = "c",
				Parent = new ParentReference
				{
					GroupId = "group",
					ArtifactId = "b",
					Version = "1.0.0-SNAPSHOT",
				},
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB, projectC });

			var action = new BulkSwitchToReleaseAction(repo.Object, "-test");

			action.Execute();

			Assert.That(projectB.Parent.Version, Is.EqualTo(new ComponentVersion("1.0.0-test")));
			Assert.That(projectB.Version.IsDefined, Is.False);

			Assert.That(projectC.Parent.Version, Is.EqualTo(new ComponentVersion("1.0.0-test")), "cascade parent version");
			Assert.That(projectC.Version.IsDefined, Is.False);
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
			// REVIEW: should we fail, when switch to release and parent is snapshot?
		}

	}
}
