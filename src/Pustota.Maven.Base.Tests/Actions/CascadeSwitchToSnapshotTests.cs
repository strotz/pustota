﻿using System;
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
				Version = "1.0.0"
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { project });

			var action = new CascadeSwitchAction(repo.Object);

			action.ExecuteFor(project);

			Assert.That(project.Version, Is.EqualTo("1.0.1-SNAPSHOT"));
			Assert.True(project.ReferenceOperations().IsSnapshot);
		}

		[Test]
		public void SingleProjectNoSwitchTest()
		{
			var project = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.1-SNAPSHOT"
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { project });

			var action = new CascadeSwitchAction(repo.Object);

			action.ExecuteFor(project);

			Assert.That(project.Version, Is.EqualTo("1.0.1-SNAPSHOT"));
			Assert.True(project.ReferenceOperations().IsSnapshot);
		}

		[Test]
		public void TwoProjectsParentTest()
		{
			var projectA = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0"
			};

			var projectB = new Project
			{
				GroupId = "group",
				ArtifactId = "b",
				Version = "1.0.1",
				Parent = new ParentReference{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0",
				},
			};

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new CascadeSwitchAction(repo.Object);

			action.ExecuteFor(projectA);

			Assert.That(projectA.Version, Is.EqualTo("1.0.1-SNAPSHOT"));
			Assert.True(projectA.ReferenceOperations().IsSnapshot);

			Assert.That(projectB.Version, Is.EqualTo("1.0.2-SNAPSHOT"));
			Assert.True(projectB.ReferenceOperations().IsSnapshot);
		}
	}
}