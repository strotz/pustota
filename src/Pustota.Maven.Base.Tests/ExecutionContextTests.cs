using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization;
using Pustota.Maven.SystemServices;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ExecutionContextTests
	{
		private ExecutionContextInstance _context;
		private Mock<IProject> _project;
		private Mock<IProject> _parent;
		private ProjectTreeElement _item;
		private Mock<IParentReference> _parentReference;
		private FullPath _projectPath;
		private Mock<IPathCalculator> _pathCalculator;

		internal class ExecutionContextInstance : ExecutionContext
		{
			internal ExecutionContextInstance(IFileSystemAccess system, IPathCalculator pathCalculator)
				: base(system, pathCalculator)
			{
			}

			public void CallReset()
			{
				base.Reset();
			}

			public void CallAdd(IProjectTreeItem item)
			{
				base.Add(item);
			}
		}

		[SetUp]
		public void Initialize()
		{
			var system = new Mock<IFileSystemAccess>();
			_pathCalculator = new Mock<IPathCalculator>();

			_context = new ExecutionContextInstance(system.Object, _pathCalculator.Object);

			_project = new Mock<IProject>();
			_projectPath = new FullPath("/a/b/c/d/pom.xml");

			_item = new ProjectTreeElement
			{
				Project = _project.Object,
				Path = _projectPath
			};
			_parent = new Mock<IProject>();

			_parentReference = new Mock<IParentReference>();
		}

		[Test] // to cover not implemented 
		public void EmptyTest()
		{
			_context.CallReset();

			_context.CallAdd(_item);
			_context.GetResolvedData(_project.Object);
			IProject found;
			_context.TryGetParentByPath(null, out found);
		}

		[Test]
		public void GoodFindDirectTest()
		{
			_parentReference.Setup(pr => pr.RelativePath).Returns("../pom.xml");
			_project.Setup(p => p.Parent).Returns(_parentReference.Object);

			var parentPath = new FullPath("/a/b/c/pom.xml");
			var parentItem = new ProjectTreeElement
			{
				Project = _parent.Object,
				Path = parentPath
			};

			_pathCalculator.Setup(c => c.CalculateParentPath(_projectPath, "../pom.xml")).Returns(parentPath);

			_context.CallAdd(_item);
			_context.CallAdd(parentItem);

			IProject foundProject;
			bool found = _context.TryGetParentByPath(_project.Object, out foundProject);

			Assert.True(found);
			Assert.That(foundProject, Is.Not.Null);
			Assert.That(foundProject, Is.EqualTo(_parent.Object));
		}
	}
}