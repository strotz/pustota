using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ProjectTreeClassTests
	{
		private ProjectTreeInstance _tree;

		internal class ProjectTreeInstance : ProjectTree
		{
		}

		[SetUp]
		public void Initialize()
		{
			_tree = new ProjectTreeInstance();
		}

		[Test] // check that all methods implemented 
		public void EmptyTest()
		{
			Assert.That(_tree.AllProjects, Is.Not.Null);

			var reference = new Mock<IProjectReference>();
			IProject foundProject;
			_tree.TryGetProject(reference.Object, out foundProject);

			FullPath path;
			_tree.TryGetPathByProject(foundProject, out path);
			_tree.TryGetProjectByPath(path, out foundProject);
		}


	}
}