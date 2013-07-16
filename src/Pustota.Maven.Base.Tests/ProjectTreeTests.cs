using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Base.Serialization;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ProjectTreeTests
	{
		private string topFolder;
		private string secondFolder;

		private string topProjectPath;
		private string secondProjectPath;

		private Project topProject;
		private Project secondProject;

		private string topProjectContent;
		private string secondProjectContent;

		private Mock<IFileSystemAccess> _fileIOMock;
		private string secondFolderName;

		[SetUp]
		public void SimpleTreeSetup()
		{
			topProject = new Project()
			{
				GroupId = "a",
				ArtifactId = "a"
			};
			secondProject =
				new Project()
				{
					GroupId = "b",
					ArtifactId = "b"
				};

			var serializer = new ProjectSerializer();
			topProjectContent = serializer.Serialize(topProject);
			secondProjectContent = serializer.Serialize(secondProject);

			topFolder = "top";
			secondFolderName = "second";
			secondFolder = "top\\second";
			topProjectPath = "top\\pom.xml";
			secondProjectPath = "top\\second\\pom.xml";

			_fileIOMock = new Mock<IFileSystemAccess>();
			_fileIOMock.Setup(io => io.ReadAllText(topProjectPath)).Returns(topProjectContent);
			_fileIOMock.Setup(io => io.ReadAllText(secondProjectPath)).Returns(secondProjectContent);
			_fileIOMock.Setup(io => io.IsFileExist(topProjectPath)).Returns(true);
			_fileIOMock.Setup(io => io.IsFileExist(secondProjectPath)).Returns(true);
			_fileIOMock.Setup(io => io.IsDirectoryExist(topFolder)).Returns(true);
			_fileIOMock.Setup(io => io.EnumerateDirectories(topFolder)).Returns(new string[] {secondFolderName});
			_fileIOMock.Setup(io => io.Combine(It.IsAny<string>(), It.IsAny<string>())).Returns(
				(string s1, string s2) => (s1 + '\\' + s2));
			_fileIOMock.Setup(io => io.Combine(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(
			(string s1, string s2, string s3) => (s1 + '\\' + s2 + '\\' + s3));
			_fileIOMock.Setup(io => io.GetDirectoryName(topProjectPath)).Returns(topFolder);
			_fileIOMock.Setup(io => io.GetDirectoryName(secondProjectPath)).Returns(secondFolder);
		}

		[Test]
		public void ProjectRepositoryBasics()
		{
			var entryPoint = new RepositoryEntryPoint("fake project folder path");
			var serializer = new Mock<IProjectSerializer>();

			var loader = new ProjectTreeLoader(entryPoint, serializer.Object, _fileIOMock.Object);
		}

		[Test]
		public void SingleProjectLoadTest()
		{
			string projectPath = "fake project path";
			var entryPoint = new RepositoryEntryPoint(projectPath);
			
			var serializer = new ProjectSerializer();

			var loader = new ProjectTreeLoader(entryPoint, serializer, _fileIOMock.Object);

			Project project = loader.LoadProjectFile(topProjectPath);

			Assert.That(project, Is.Not.Null);
			Assert.That(project.ArtifactId, Is.EqualTo(topProject.ArtifactId));
		}

		[Test]
		public void ProjectRepositoryLoadAllFoldersTest()
		{
			var entryPoint = new RepositoryEntryPoint(topFolder);
			var serializer = new ProjectSerializer();

			var loader = new ProjectTreeLoader(entryPoint, serializer, _fileIOMock.Object);
			var projects = loader.LoadProjects().ToList();

			Assert.That(projects.Count, Is.EqualTo(2));
		}

		[Test]
		public void ProjectRepositoryLoadViaModulesJustOneTest()
		{
			var entryPoint = new RepositoryEntryPoint(topProjectPath);
			var serializer = new ProjectSerializer();

			var loader = new ProjectTreeLoader(entryPoint, serializer, _fileIOMock.Object);
			var projects = loader.LoadProjects().ToList();

			Assert.That(projects.Count, Is.EqualTo(1));
		}

		[Test]
		public void ProjectRepositoryLoadViaModulesAllTest()
		{
			topProject.Modules.Add(new Module(){Path = secondFolderName});
			var content = new ProjectSerializer().Serialize(topProject);

			_fileIOMock.Setup(io => io.ReadAllText(topProjectPath)).Returns(content);

			var entryPoint = new RepositoryEntryPoint(topProjectPath);
			var serializer = new ProjectSerializer();

			var loader = new ProjectTreeLoader(entryPoint, serializer, _fileIOMock.Object);
			var projects = loader.LoadProjects().ToList();

			Assert.That(projects.Count, Is.EqualTo(2));
		}
	
	}
}
