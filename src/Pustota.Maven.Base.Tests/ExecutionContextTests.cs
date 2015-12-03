using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ExecutionContextTests
	{
		private ExecutionContextInstance _context;
		private Mock<IProject> _project;
		private Mock<IProject> _other;
		private ProjectTreeElement _item;
		private Mock<IParentReference> _parentReference;
		private FullPath _projectPath;
		private Mock<IPathCalculator> _pathCalculator;
		private Mock<IModule> _module;

		internal class ExecutionContextInstance : ExecutionContext
		{
			internal ExecutionContextInstance(IPathCalculator pathCalculator)
				: base(pathCalculator)
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
			_pathCalculator = new Mock<IPathCalculator>();

			_context = new ExecutionContextInstance(_pathCalculator.Object);

			_project = new Mock<IProject>();
			_projectPath = new FullPath("/a/b/c/d/pom.xml");

			_item = new ProjectTreeElement
			{
				Project = _project.Object,
				Path = _projectPath
			};
			_other = new Mock<IProject>();

			_parentReference = new Mock<IParentReference>();
			_module = new Mock<IModule>();
		}

		[Test] // to cover not implemented 
		public void EmptyTest()
		{
			_context.CallReset();

			_context.CallAdd(_item);

			IProject found;
			_context.TryGetParentByPath(null, out found);
			_context.TryGetModule(null, "", out found);
		}

		[Test]
		public void GoodFindDirectTest()
		{
			_parentReference.Setup(pr => pr.RelativePath).Returns("../pom.xml");
			_project.Setup(p => p.Parent).Returns(_parentReference.Object);

			var parentPath = new FullPath("/a/b/c/pom.xml");
			var parentItem = new ProjectTreeElement
			{
				Project = _other.Object,
				Path = parentPath
			};

			_pathCalculator.Setup(c => c.CalculateParentPath(_projectPath, "../pom.xml")).Returns(parentPath);

			_context.CallAdd(_item);
			_context.CallAdd(parentItem);

			IProject foundProject;
			bool found = _context.TryGetParentByPath(_project.Object, out foundProject);

			Assert.True(found);
			Assert.That(foundProject, Is.Not.Null);
			Assert.That(foundProject, Is.EqualTo(_other.Object));
		}

		[Test]
		public void GoodFindModuleTest()
		{
			_module.Setup(m => m.Path).Returns("child");
			var modules = new List<IModule>();
			modules.Add(_module.Object);

			var modulePath = new FullPath("/a/b/c/pom.xml");
			var moduleItem = new ProjectTreeElement
			{
				Project = _other.Object,
				Path = modulePath
			};

			_project.Setup(p => p.Modules).Returns(modules);
			_project.Setup(p => p.Profiles).Returns(new List<IProfile>());

			FullPath fullPath = new FullPath(modulePath);
			_pathCalculator.Setup(c => c.TryResolveModulePath(_projectPath, "child", out fullPath)).Returns(true);

			_context.CallAdd(_item);
			_context.CallAdd(moduleItem);

			IProject foundModule;
			bool found = _context.TryGetModule(_project.Object, "child", out foundModule);

			Assert.True(found);
			Assert.That(foundModule, Is.Not.Null);
		}
	}
}