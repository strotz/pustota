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
	[TestFixture]
	public class CascadeSwitchToSnapshotTests
	{
		[SetUp]
		public void Initialize()
		{
		}

		[TearDown]
		public void Shutdown()
		{
		}

		[Test]
		public void SingleProjectTest()
		{
			var project = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0".ToVersion()
            };

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { project });

			var action = new CascadeSwitchAction(repo.Object);

			action.ExecuteFor(project);

			Assert.That(project.Version.Value, Is.EqualTo("1.0.1-SNAPSHOT"));
		}

		[Test]
		public void SingleProjectNoSwitchTest()
		{
			var project = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.1-SNAPSHOT".ToVersion()
            };

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { project });

			var action = new CascadeSwitchAction(repo.Object);

			action.ExecuteFor(project);

			Assert.That(project.Version.Value, Is.EqualTo("1.0.1-SNAPSHOT"));
		}

		[Test]
		public void TwoProjectsParentTest()
		{
			var projectA = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0".ToVersion()
            };

			var projectB = new Project
			{
				GroupId = "group",
				ArtifactId = "b",
				Version = "1.0.1".ToVersion(),
				Parent = new ParentReference{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0".ToVersion()
                },
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new CascadeSwitchAction(repo.Object);

			action.ExecuteFor(projectA);

			Assert.That(projectA.Version.Value, Is.EqualTo("1.0.1-SNAPSHOT"));
			Assert.That(projectB.Version.Value, Is.EqualTo("1.0.2-SNAPSHOT"));
		}

		[Test]
		public void TwoProjectsVersionInheritedParentTest()
		{
			var projectA = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0".ToVersion()
            };

			var projectB = new Project
			{
				GroupId = "group",
				ArtifactId = "b",
				Parent = new ParentReference
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0".ToVersion()
                },
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new CascadeSwitchAction(repo.Object);

			action.ExecuteFor(projectA);

			Assert.That(projectA.Version.Value, Is.EqualTo("1.0.1-SNAPSHOT"));

			Assert.That(projectB.Version.IsDefined, Is.False);
			Assert.That(projectB.Parent.Version.Value, Is.EqualTo("1.0.1-SNAPSHOT"));
		}

		[Test]
		public void ThreeProjectsCascadeParentTest()
		{
			var projectA = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0".ToVersion()
            };

			var projectB = new Project
			{
				GroupId = "group",
				ArtifactId = "b",
				Parent = new ParentReference
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0".ToVersion()
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
					Version = "1.0.0".ToVersion()
                },
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB, projectC });

			var action = new CascadeSwitchAction(repo.Object);

			action.ExecuteFor(projectA);

			Assert.That(projectA.Version.Value, Is.EqualTo("1.0.1-SNAPSHOT"));

			Assert.That(projectB.Parent.Version.Value, Is.EqualTo("1.0.1-SNAPSHOT"));
			Assert.That(projectB.Version.IsDefined, Is.False);

			Assert.That(projectC.Parent.Version.Value, Is.EqualTo("1.0.1-SNAPSHOT"));
			Assert.That(projectC.Version.IsDefined, Is.False);
		}

		[Test]
		public void InheritedParentTest()
		{
			var projectA = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0".ToVersion()
            };

			var projectB = new Project
			{
				GroupId = "group",
				ArtifactId = "b",
				Parent = new ParentReference
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0".ToVersion()
                },
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new CascadeSwitchAction(repo.Object);

			action.ExecuteFor(projectB);

			Assert.That(projectA.Version.Value, Is.EqualTo("1.0.0"));
			Assert.That(projectB.Version.Value, Is.EqualTo("1.0.1-SNAPSHOT"));
		}
	}
}
