using Moq;
using NUnit.Framework;
using Pustota.Maven.Serialization;
using Pustota.Maven.System;

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
			_fileIo.Setup(f => f.GetDirectoryName(FileName)).Returns(BaseDir);
			_fileIo.Setup(f => f.GetFullPath(FileName)).Returns(FileName);

			_treeLoader = new Mock<IProjectTreeLoader>();

			_solution = new Solution(_fileIo.Object, _treeLoader.Object);
		}

		[Test]
		public void OpenSolutionCalculatesBasedirForFileTest()
		{
			_solution.Open(FileName);
			_fileIo.Verify(io => io.GetFullPath(FileName));
			Assert.That(_solution.BaseDir, Is.EqualTo(BaseDir));
		}

		[Test]
		public void OpenSolutionLoadsProjectsTest()
		{
			_solution.Open(FileName);
			_treeLoader.Verify(l => l.LoadProjectTree(FileName), Times.Once());
		}
	}
}
