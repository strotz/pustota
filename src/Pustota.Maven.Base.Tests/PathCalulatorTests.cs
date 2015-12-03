using System.CodeDom;
using Moq;
using NUnit.Framework;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class PathCalulatorTests
	{
		private const string Target = @"c:\a\b\c\d";
		private const string Source = @"c:\a\b\pom.xml";
		private const string Path = @"c\d";
		private const string FileTarget = Target + "\\" + PathCalculator.ProjectFilePattern;

		private Mock<IFileSystemAccess> _system; 
		private PathCalculator _pathCalculator;


		[SetUp]
		public void Initialize()
		{
			_system = new Mock<IFileSystemAccess>();

			const string baseDir = @"c:\a\b\";

			_system.Setup(s => s.Normalize(Path)).Returns(Path);
			_system.Setup(s => s.GetDirectoryName(Source)).Returns(baseDir);
			
			_system.Setup(s => s.Combine(baseDir, Path)).Returns(Target);
			_system.Setup(s => s.Combine(Target, PathCalculator.ProjectFilePattern)).Returns(FileTarget);

			_system.Setup(s => s.GetFullPath(It.IsAny<string>())).Returns((string s) => s);

			_pathCalculator = new PathCalculator(_system.Object);
		}

		[Test]
		public void ParentPathCalculatorTest()
		{
			_pathCalculator = new PathCalculator(new FileSystemAccess());
			var result = _pathCalculator.CalculateParentPath(new FullPath(@"c:\a\b\c\d\pom.xml"), "../pom.xml");
			Assert.That(result.Value, Is.EqualTo(@"c:\a\b\c\pom.xml"));
		}

		[Test]
		public void ModulePathIsDirectoryWithPomTest()
		{
			_system.Setup(s => s.IsDirectoryExist(Target)).Returns(true);
			_system.Setup(s => s.IsFileExist(FileTarget)).Returns(true);

			FullPath result; 
			Assert.True(_pathCalculator.TryResolveModulePath(new FullPath(Source), Path, out result));
			Assert.That(result.Value, Is.EqualTo(FileTarget));
		}

		[Test]
		public void ModulePathIsDirectoryWithoutPomTest()
		{
			_system.Setup(s => s.IsDirectoryExist(Target)).Returns(true);
			_system.Setup(s => s.IsFileExist(FileTarget)).Returns(false);

			FullPath result;
			Assert.False(_pathCalculator.TryResolveModulePath(new FullPath(Source), Path, out result));
			Assert.That(result.Value, Is.EqualTo(FullPath.Undefined.Value));
		}

		[Test]
		public void ModulePathIsFileTest()
		{
			_system.Setup(s => s.IsDirectoryExist(Target)).Returns(false);
			_system.Setup(s => s.IsFileExist(Target)).Returns(true);

			FullPath result;
			Assert.True(_pathCalculator.TryResolveModulePath(new FullPath(Source), Path, out result));
			Assert.That(result.Value, Is.EqualTo(Target));
		}

		[Test]
		public void ModulePathNotExistTest()
		{
			_system.Setup(s => s.IsDirectoryExist(Target)).Returns(false);
			_system.Setup(s => s.IsFileExist(Target)).Returns(false);

			FullPath result;
			Assert.False(_pathCalculator.TryResolveModulePath(new FullPath(Source), Path, out result));
			Assert.That(result.Value, Is.EqualTo(FullPath.Undefined.Value));
		}

	}
}