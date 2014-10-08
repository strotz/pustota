using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	public class ProjecModulesValidationTests : ValidationTestBase
	{
		private ProjecModulesValidation _validator;

		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_validator = new ProjecModulesValidation();
		}

		[Test]
		public void EmptyTest()
		{
			_validator.Validate(Context.Object, Project.Object);
		}

		[Test]
		public void ProjectWithBadModuleTest()
		{
			var modules = new List<IModule>();
			modules.Add(new Module
			{
				Path = "child"
			});
			Project.Setup(p => p.Modules).Returns(modules);
			Project.Setup(p => p.Profiles).Returns(new List<IProfile>());

			var result = (ValidationProblem) _validator.Validate(Context.Object, Project.Object).Single();
			Assert.That(result.ProblemCode, Is.EqualTo("modulemissing"));
		}

		[Test]
		public void ProjectWithGoodModuleTest()
		{
			var modules = new List<IModule>();
			modules.Add(new Module
			{
				Path = "child"
			});
			Project.Setup(p => p.Modules).Returns(modules);
			Project.Setup(p => p.Profiles).Returns(new List<IProfile>());

			var module = new Mock<IProject>();
			IProject foundModule = module.Object;
			Context.Setup(c => c.TryGetModule(Project.Object, "child", out foundModule)).Returns(true);

			var result = _validator.Validate(Context.Object, Project.Object).Any();
			Assert.That(result, Is.False);
		}
	}
}
