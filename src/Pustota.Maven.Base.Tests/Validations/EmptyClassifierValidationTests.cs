using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class EmptyClassifierValidationTests : ValidationTestBase
	{
		private EmptyClassifierValidation _validator;

		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_validator = new EmptyClassifierValidation();
		}

		[Test]
		public void EmptyTest()
		{
			_validator.Validate(Context.Object, Project.Object);
		}

		[Test]
		public void EmptyCalssifierTest()
		{
			var dependency = new Mock<IDependency>();
			dependency.Setup(d => d.Classifier).Returns(string.Empty);
			var list = new List<IDependency>();
			list.Add(dependency.Object);

			Project.Setup(p => p.Dependencies).Returns(list);
			Project.Setup(p => p.DependencyManagement).Returns(new List<IDependency>());
			Project.Setup(p => p.Profiles).Returns(new List<IProfile>());
		    Project.Setup(p => p.Plugins).Returns(new List<IPlugin>());

            var result = _validator.Validate(Context.Object, Project.Object);
			Assert.NotNull(result);
			var problem = (ValidationProblem)result.Single();
			Assert.That(problem.ProblemCode, Is.EqualTo("emptyclassifier"));
		}
	}
}