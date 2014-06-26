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

			Assert.That(project.Version, Is.EqualTo("1.0.0-test"));
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

			Assert.That(projectA.Version, Is.EqualTo("1.0.0-test"));
			Assert.False(projectA.ReferenceOperations().IsSnapshot);

			Assert.That(projectB.Version, Is.EqualTo("1.0.1-test"));
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

			Assert.That(projectB.Parent.Version, Is.EqualTo("1.0.0-test"));
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
			Assert.That(dependency.Version, Is.EqualTo("1.0.0-test"));
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
			Assert.That(plugin.Version, Is.EqualTo("1.0.0-test"));
			Assert.False(plugin.ReferenceOperations().IsSnapshot);
		}

	}
}
