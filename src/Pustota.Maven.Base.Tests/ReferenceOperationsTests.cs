using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;

namespace Pustota.Maven.Base.Tests
{

	public class ReferenceOperationsTests
	{
		private Mock<IProjectReference> _project;
		private IProjectReferenceOperations _operations;

		[SetUp]
		public void Initialize()
		{
			_project = new Mock<IProjectReference>();
			_operations = new ProjectReferenceOperations(_project.Object);
		}
	}
}
