using System.Linq;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Actions;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ApplyClassifierActionTests
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

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA, projectB });

			var action = new ApplyClassifierAction(repo.Object, "test", "Release");

			action.Execute();

			var dependency = projectB.Dependencies.Single();
			Assert.That(dependency.Classifier, Is.EqualTo("Release"));
		}

		[Test]
		public void ProjectWithProfileDependencyTest()
		{
			var projectA = new Project
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0-SNAPSHOT",
			};
			projectA.Dependencies.Add(
				new Dependency
				{
					GroupId = "group",
					ArtifactId = "a",
					Version = "1.0.0-SNAPSHOT",
					Classifier = "${test}"
				}
				);
			var profile = new Profile();
			profile.Dependencies.Add(new Dependency
			{
				GroupId = "group",
				ArtifactId = "a",
				Version = "1.0.0-SNAPSHOT",
				Classifier = "${test}"
			}
			);

			projectA.Profiles.Add(profile);

			var repo = new Mock<IProjectsRepository>();
			repo.SetupGet(r => r.AllProjects).Returns(new IProject[] { projectA });

			var action = new ApplyClassifierAction(repo.Object, "test", "Release");

			action.Execute();

			var dependency = projectA.Dependencies.Single();
			Assert.That(dependency.Classifier, Is.EqualTo("Release"));

			var dependency2 = projectA.Profiles.Single().Dependencies.Single();
			Assert.That(dependency2.Classifier, Is.EqualTo("Release"));
		}
	}
}