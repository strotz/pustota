using Moq;
using NUnit.Framework;
using Pustota.Maven.Serialization;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class SolutionTests
	{
		private Mock<IFileSystemAccess> _fileIo;
		private Mock<IProjectTreeLoader> _treeLoader;
		
		private Solution _solution;
		
		private const string FileName = "file";
		private const string BaseDir = "baseDir";

		[SetUp]
		public void Initialize()
		{
			_fileIo = new Mock<IFileSystemAccess>();
			_fileIo.Setup(f => f.IsFileExist(FileName)).Returns(true);
			_fileIo.Setup(f => f.IsDirectoryExist(BaseDir)).Returns(true);
			_fileIo.Setup(f => f.GetDirectoryName(FileName)).Returns(BaseDir);
			_fileIo.Setup(f => f.GetFullPath(FileName)).Returns(FileName);
			_fileIo.Setup(f => f.GetFullPath(BaseDir)).Returns(BaseDir);
			_fileIo.Setup(f => f.Combine(BaseDir, "pom.xml")).Returns(FileName);

			_treeLoader = new Mock<IProjectTreeLoader>();

			_solution = new Solution(_fileIo.Object, _treeLoader.Object);
		}

		[Test]
		public void OpenSolutionCalculatesBasedirForFileTest()
		{
			_solution.Open(FileName, true);
			_fileIo.Verify(io => io.GetFullPath(FileName));
			Assert.That(_solution.BaseDir, Is.EqualTo(BaseDir));
		}

		[Test]
		public void OpenSolutionCalculatesBasedirForFolderTest()
		{
			_solution.Open(BaseDir, true);
			_fileIo.Verify(io => io.GetFullPath(BaseDir));
			Assert.That(_solution.BaseDir, Is.EqualTo(BaseDir));
		}

		[Test]
		public void LoadDisconnectedWillCallScanForProjectsWithFolderTest()
		{
			_solution.Open(BaseDir, true);
			_treeLoader.Verify(l => l.ScanForProjects(BaseDir), Times.Once());
		}

		[Test]
		public void LoadDisconnectedWillCallScanForProjectsWithFileTest()
		{
			_solution.Open(FileName, true);
			_treeLoader.Verify(l => l.ScanForProjects(BaseDir), Times.Once());
		}

		[Test]
		public void OpenSolutionLoadsProjectsTest()
		{
			_solution.Open(FileName, false);
			_treeLoader.Verify(l => l.LoadProjectTree(FileName), Times.Once());
		}

		[Test]
		public void OpenSolutionLoadsProjectTreeTest()
		{
			_solution.Open(BaseDir, false);
			_treeLoader.Verify(l => l.LoadProjectTree(FileName), Times.Once());
		}
	}
}
