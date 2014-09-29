using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pustota.Maven.Models;
using Pustota.Maven.Validation;

namespace Pustota.Maven.Base.Tests.Validations
{
	[TestFixture]
	public class ProjectPluginVersionsTest : ValidationTestBase
	{
		private ProjectPluginVersionsValidation _projectValidator;
		
		[SetUp]
		public void Initialize()
		{
			CreateContext();

			_projectValidator = new ProjectPluginVersionsValidation();

			Project.Setup(p => p.Plugins).Returns(new List<IPlugin>());
			Project.Setup(p => p.PluginManagement).Returns(new List<IPlugin>());
			Project.Setup(p => p.Profiles).Returns(new List<IProfile>());
		}

		[Test]
		public void EmptyTest()
		{
			var result = _projectValidator.Validate(Context.Object, Project.Object);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test, Ignore]
		public void UndefinedPluginTest()
		{
			throw new NotImplementedException();
		}
	}
}