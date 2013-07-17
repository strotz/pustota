using System.Linq;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Base.Data;
using Pustota.Maven.Base.Serialization;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ProjectTreeTests
	{
		private string _topFolder;
		private string _secondFolder;

		private string _topProjectPath;
		private string _secondProjectPath;

		private Project _topProject;
		private Project _secondProject;

		private string _topProjectContent;
		private string _secondProjectContent;

		private Mock<IFileSystemAccess> _fileIOMock;
		private string _secondFolderName;

		[SetUp]
		public void SimpleTreeSetup()
		{
			_topProject = new Project
			{
				GroupId = "a",
				ArtifactId = "a"
			};
			_secondProject =
				new Project
				{
					GroupId = "b",
					ArtifactId = "b"
				};

			var serializer = new ProjectSerializer();
			_topProjectContent = serializer.Serialize(_topProject);
			_secondProjectContent = serializer.Serialize(_secondProject);

			_topFolder = "top";
			_secondFolderName = "second";
			_secondFolder = "top\\second";
			_topProjectPath = "top\\pom.xml";
			_secondProjectPath = "top\\second\\pom.xml";

			_fileIOMock = new Mock<IFileSystemAccess>();
			_fileIOMock.Setup(io => io.ReadAllText(_topProjectPath)).Returns(_topProjectContent);
			_fileIOMock.Setup(io => io.ReadAllText(_secondProjectPath)).Returns(_secondProjectContent);
			_fileIOMock.Setup(io => io.IsFileExist(_topProjectPath)).Returns(true);
			_fileIOMock.Setup(io => io.IsFileExist(_secondProjectPath)).Returns(true);
			_fileIOMock.Setup(io => io.IsDirectoryExist(_topFolder)).Returns(true);
			_fileIOMock.Setup(io => io.EnumerateDirectories(_topFolder)).Returns(new[] {_secondFolderName});
			_fileIOMock.Setup(io => io.Combine(It.IsAny<string>(), It.IsAny<string>())).Returns(
				(string s1, string s2) => (s1 + '\\' + s2));
			_fileIOMock.Setup(io => io.Combine(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(
			(string s1, string s2, string s3) => (s1 + '\\' + s2 + '\\' + s3));
			_fileIOMock.Setup(io => io.GetDirectoryName(_topProjectPath)).Returns(_topFolder);
			_fileIOMock.Setup(io => io.GetDirectoryName(_secondProjectPath)).Returns(_secondFolder);
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

			Project project = loader.LoadProjectFile(_topProjectPath);

			Assert.That(project, Is.Not.Null);
			Assert.That(project.ArtifactId, Is.EqualTo(_topProject.ArtifactId));
		}

		[Test]
		public void ProjectRepositoryLoadAllFoldersTest()
		{
			var entryPoint = new RepositoryEntryPoint(_topFolder);
			var serializer = new ProjectSerializer();

			var loader = new ProjectTreeLoader(entryPoint, serializer, _fileIOMock.Object);
			var projects = loader.LoadProjects().ToList();

			Assert.That(projects.Count, Is.EqualTo(2));
		}

		[Test]
		public void ProjectRepositoryLoadViaModulesJustOneTest()
		{
			var entryPoint = new RepositoryEntryPoint(_topProjectPath);
			var serializer = new ProjectSerializer();

			var loader = new ProjectTreeLoader(entryPoint, serializer, _fileIOMock.Object);
			var projects = loader.LoadProjects().ToList();

			Assert.That(projects.Count, Is.EqualTo(1));
		}

		[Test]
		public void ProjectRepositoryLoadViaModulesAllTest()
		{
			_topProject.Modules.Add(new Module {Path = _secondFolderName});
			var content = new ProjectSerializer().Serialize(_topProject);

			_fileIOMock.Setup(io => io.ReadAllText(_topProjectPath)).Returns(content);

			var entryPoint = new RepositoryEntryPoint(_topProjectPath);
			var serializer = new ProjectSerializer();

			var loader = new ProjectTreeLoader(entryPoint, serializer, _fileIOMock.Object);
			var projects = loader.LoadProjects().ToList();

			Assert.That(projects.Count, Is.EqualTo(2));
		}
	
	}
}
