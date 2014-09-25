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

		internal class ExecutionContextInstance : ExecutionContext
		{
			internal ExecutionContextInstance(IFileSystemAccess system)
				: base(system)
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
			_context = new ExecutionContextInstance(system.Object);
		}

		[Test] // to cover not implemented 
		public void EmptyTest()
		{
			_context.CallReset();

			var project = new Mock<IProject>();
			var item = new ProjectTreeElement
			{
				Project = project.Object
			};

			_context.CallAdd(item);
			_context.GetResolvedData(project.Object);
			IProject found;
			_context.TryGetParentByPath(null, out found);
		}
	}
}