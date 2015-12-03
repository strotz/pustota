using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Serialization;
using Pustota.Maven.Serialization.Data;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ProjectTreeTests
	{
		private string _topFolder;

		private string _topProjectPath;
		private string _secondProjectPath;

		private Project _topProject;
		private Project _secondProject;

		private string _topProjectContent;

		private Mock<IFileSystemAccess> _fileIOMock;

		private string _secondFolderName;

		private Mock<IProjectSerializerWithUpdate> _serializerMock;

		private Mock<IProjectReader> _readerMock;
		private Mock<IProjectWriter> _writerMock;

		private ProjectTreeLoader _loader;

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

			_serializerMock = new Mock<IProjectSerializerWithUpdate>();
			_readerMock = new Mock<IProjectReader>();
			_writerMock = new Mock<IProjectWriter>();

			var realSerializer = new ProjectSerializer(new DataFactory());
			_topProjectContent = realSerializer.Serialize(_topProject);

			_serializerMock.Setup(s => s.Deserialize(_topProjectContent)).Returns(_topProject);

			_topFolder = "top";
			_secondFolderName = "second";
			_topProjectPath = "top\\pom.xml";
			_secondProjectPath = "top\\second\\pom.xml";

			_fileIOMock = new Mock<IFileSystemAccess>();
			_fileIOMock.Setup(io => io.GetFullPath(It.IsAny<string>())).Returns((string s) => s);

			// load tree
			_fileIOMock.Setup(io => io.ReadAllText(_topProjectPath)).Returns(_topProjectContent);
			_fileIOMock.Setup(io => io.IsFileExist(_topProjectPath)).Returns(true);
			_fileIOMock.Setup(io => io.IsFileExist(_secondProjectPath)).Returns(true);

			// scan for files
			_fileIOMock.Setup(io => io.IsDirectoryExist(_topFolder)).Returns(true);
			_fileIOMock.Setup(io => io.GetFiles(_topFolder, "pom.xml", SearchOption.AllDirectories))
				.Returns(new[] { _topProjectPath, _secondProjectPath });

			Mock<IPathCalculator> path = new Mock<IPathCalculator>();
			FullPath topFullPath = new FullPath(_topProjectPath);
			FullPath seconFullPath = new FullPath(_secondProjectPath);
			path.Setup(p => p.TryResolveModulePath(topFullPath, _secondFolderName, out seconFullPath)).Returns(true);

			_readerMock.Setup(l => l.ReadProject(_topProjectPath)).Returns(_topProject);
			_readerMock.Setup(l => l.ReadProject(_secondProjectPath)).Returns(_secondProject);

			_loader = new ProjectTreeLoader(_fileIOMock.Object, _readerMock.Object, _writerMock.Object, path.Object, new NoLog()); 
		}

		[Test]
		public void ProjectLoaderTest()
		{
			var loader = new ProjectLoader(_fileIOMock.Object, _serializerMock.Object, NoLog.Instance);
			var project = loader.ReadProject(_topProjectPath);

			Assert.That(project, Is.Not.Null);
			Assert.That(project.ArtifactId, Is.EqualTo(_topProject.ArtifactId));
		}

		[Test]
		public void ProjectRepositoryLoadViaModulesJustOneTest()
		{
			var projects = _loader.LoadProjectTree(_topProjectPath).ToList();

			Assert.That(projects.Count, Is.EqualTo(1));
			Assert.That(projects.Single().Project.ArtifactId, Is.EqualTo(_topProject.ArtifactId));
			Assert.That(projects.Single().Path.Value, Is.EqualTo(_topProjectPath));
		}

		[Test]
		public void ProjectRepositoryLoadViaModulesAllTest()
		{
			_topProject.Modules.Add(new Module { Path = _secondFolderName });
			var projects = _loader.LoadProjectTree(_topProjectPath).ToList();
			Assert.That(projects.Count, Is.EqualTo(2));
		}

		[Test]
		public void ProjectRepositoryLoadViaModulesSomeTest()
		{
			_topProject.Modules.Add(new Module { Path = _secondFolderName });
			_topProject.Modules.Add(new Module { Path = "fake" }); // module does not exist, it will be logged 
			var projects = _loader.LoadProjectTree(_topProjectPath).ToList();
			Assert.That(projects.Count, Is.EqualTo(2));
			// TODO: check that error logged
		}

		[Test]
		public void ProjectRepositoryScansAllFoldersTest()
		{
			var projects = _loader.ScanForProjects(_topFolder).ToList();
			Assert.That(projects.Count, Is.EqualTo(2));
			_readerMock.Verify(r => r.ReadProject(It.IsAny<string>()), Times.Exactly(2));
		}

		[Test]
		public void ProjectSaveCallsWriterTests()
		{
			var elements = new List<ProjectTreeElement>
			{
				new ProjectTreeElement(new FullPath(_topProjectPath), _topProject),
				new ProjectTreeElement(new FullPath(_secondProjectPath), _secondProject)
			};

			_loader.SaveProjects(elements);

			_writerMock.Verify(w => w.UpdateProject(_topProject, _topProjectPath), Times.Once());
			_writerMock.Verify(w => w.UpdateProject(_secondProject, _secondProjectPath), Times.Once());
		}
	}
}
