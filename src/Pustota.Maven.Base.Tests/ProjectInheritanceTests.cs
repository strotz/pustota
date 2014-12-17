using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Actions;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ProjectInheritanceTests
	{
		private Mock<IProjectsRepository> _repo; 
		private ProjectInheritanceFolder _folder;

		private Mock<IProject> _parent;

		private Mock<IProject> _project; 
		private Mock<IParentReference> _parentReference;
			
		[SetUp]
		public void Initialize()
		{
			_repo = new Mock<IProjectsRepository>();

			_parentReference = new Mock<IParentReference>();
			_parentReference.Setup(pr => pr.ArtifactId).Returns("parentId");
			_parentReference.Setup(pr => pr.Version).Returns("parentVersion1");

			_project = new Mock<IProject>();
			_project.Setup(p => p.Parent).Returns(_parentReference.Object);

			_parent = new Mock<IProject>();
			_parent.Setup(pr => pr.ArtifactId).Returns("parentId");

			IProject foundParentByRef = _parent.Object;
			_repo.Setup(r => r.TryGetProject(_parentReference.Object, out foundParentByRef, true)).Returns(true);

			_folder = new ProjectInheritanceFolder(_repo.Object);
		}

		[Test]
		public void Empty()
		{
			Assert.IsNotNull(_folder); 
		}

		[Test]
		public void NoParentTest()
		{
			var chain = _folder.BuildInheritanceChain(_parentReference.Object);
			Assert.That(chain.Single(), Is.EqualTo(_parent.Object));
		}
	}
}
