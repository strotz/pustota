using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using Pustota.Maven.Externals;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ExternalModulesDocumentTests
	{
		[Test]
		public void Empty()
		{
			var document = new ExternalModulesDocument();
			var result = document.ReadModules();
			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.Empty);
		}

		[Test]
		public void Simple()
		{
			var xdoc = new XDocument(
				new XDeclaration("1.0", "us-utf8", null),
				new XElement("modules",
					new XElement("module",
						new XElement("groupId","a"),
						new XElement("artifactId","b"),
						new XElement("version","c")
						)
					)
				);

			var document = new ExternalModulesDocument(xdoc);
			var result = document.ReadModules();
			Assert.That(result, Is.Not.Null);
			var module = result.Single();
			Assert.That(module.GroupId, Is.EqualTo("a"));
			Assert.That(module.ArtifactId, Is.EqualTo("b"));
			Assert.That(module.Version.Value, Is.EqualTo("c"));
		}
	}
}