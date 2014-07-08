using System.Linq;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Serialization;
using Pustota.Maven.Serialization.Data;
using Pustota.Maven.System;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ProjectTreeTests
	{
		//private string _topFolder;
		//private string _secondFolder;

		private string _topProjectPath;
		private string _secondProjectPath;

		private Project _topProject;
		private Project _secondProject;

		private string _topProjectContent;
		//private string _secondProjectContent;

		private Mock<IFileSystemAccess> _fileIOMock;

		private string _secondFolderName;

		private Mock<IProjectSerializer> _serializerMock;
		//private IProjectSerializer _serializer;

		private Mock<IProjectReader> _readerMock;

		[SetUp]
		public void SimpleTreeSetup()
		{
			_topProject = new Project
			{
				GroupId = "a",
				ArtifactId = "a"
			};
			_secondProject = new Project
				{
					GroupId = "b",
					ArtifactId = "b"
				};


			_serializerMock = new Mock<IProjectSerializer>();
			_readerMock = new Mock<IProjectReader>();

			var realSerializer = new ProjectSerializer(new DataFactory());
			_topProjectContent = realSerializer.Serialize(_topProject);
			//	_secondProjectContent = _serializer.Serialize(_secondProject);

			_serializerMock.Setup(s => s.Deserialize(_topProjectContent)).Returns(_topProject);

			//	_topFolder = "top";
			_secondFolderName = "second";
			//	_secondFolder = "top\\second";
			_topProjectPath = "top\\pom.xml";
			_secondProjectPath = "top\\second\\pom.xml";

			_fileIOMock = new Mock<IFileSystemAccess>();
			//	_fileIOMock.Setup(io => io.GetFullPath(It.IsAny<string>())).Returns((string s) => s);
			_fileIOMock.Setup(io => io.ReadAllText(_topProjectPath)).Returns(_topProjectContent);
			//	_fileIOMock.Setup(io => io.ReadAllText(_secondProjectPath)).Returns(_secondProjectContent);
			_fileIOMock.Setup(io => io.IsFileExist(_topProjectPath)).Returns(true);
			_fileIOMock.Setup(io => io.IsFileExist(_secondProjectPath)).Returns(true);
			//	_fileIOMock.Setup(io => io.IsDirectoryExist(_topFolder)).Returns(true);
			//	_fileIOMock.Setup(io => io.EnumerateDirectories(_topFolder)).Returns(new[] {_secondFolderName});

			_fileIOMock.Setup(io => io.Combine(It.IsAny<string>(), _secondFolderName, It.IsAny<string>())).Returns(_secondProjectPath);

			//	_fileIOMock.Setup(io => io.Combine(It.IsAny<string>(), It.IsAny<string>())).Returns(
			//		(string s1, string s2) => (s1 + '\\' + s2));
			//	_fileIOMock.Setup(io => io.Combine(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(
			//	(string s1, string s2, string s3) => (s1 + '\\' + s2 + '\\' + s3));
			//	_fileIOMock.Setup(io => io.GetDirectoryName(_topProjectPath)).Returns(_topFolder);
			//	_fileIOMock.Setup(io => io.GetDirectoryName(_secondProjectPath)).Returns(_secondFolder);

			_readerMock.Setup(l => l.ReadProject(_topProjectPath)).Returns(_topProject);
			_readerMock.Setup(l => l.ReadProject(_secondProjectPath)).Returns(_secondProject);
		}

		[Test]
		public void ProjectLoaderTest()
		{
			var loader = new ProjectLoader(_fileIOMock.Object, _serializerMock.Object);
			var project = loader.ReadProject(_topProjectPath);

			Assert.That(project, Is.Not.Null);
			Assert.That(project.ArtifactId, Is.EqualTo(_topProject.ArtifactId));
		}

		[Test]
		public void ProjectRepositoryBasics()
		{
			var loader = new ProjectTreeLoader(_fileIOMock.Object, _readerMock.Object);
		}

		//[Test]
		//public void ProjectRepositoryLoadAllFoldersTest()
		//{
		//	var entryPoint = new RepositoryEntryPoint(_topFolder, _fileIOMock.Object);

		//	var loader = new ProjectTreeLoader(entryPoint, _serializer, _fileIOMock.Object);
		//	var projects = loader.LoadProjects().ToList();

		//	Assert.That(projects.Count, Is.EqualTo(2));
		//}

		[Test]
		public void ProjectRepositoryLoadViaModulesJustOneTest()
		{
			var loader = new ProjectTreeLoader(_fileIOMock.Object, _readerMock.Object);
			var projects = loader.LoadProjectTree(_topProjectPath).ToList();

			Assert.That(projects.Count, Is.EqualTo(1));
			Assert.That(projects.Single().Item2.ArtifactId, Is.EqualTo(_topProject.ArtifactId));
			Assert.That(projects.Single().Item1, Is.EqualTo(_topProjectPath));
		}

		[Test]
		public void ProjectRepositoryLoadViaModulesAllTest()
		{
			_topProject.Modules.Add(new Module { Path = _secondFolderName });

			var loader = new ProjectTreeLoader(_fileIOMock.Object, _readerMock.Object);
			var projects = loader.LoadProjectTree(_topProjectPath).ToList();

			Assert.That(projects.Count, Is.EqualTo(2));
		}

	}
}
