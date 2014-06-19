using System;
using System.Xml.Linq;
using NUnit.Framework;
using Pustota.Maven.Serialization;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class ProjectModelTests
	{
		const string ProjectTemplate =
			@"<?xml version=""1.0"" encoding=""us-ascii""?>
<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">{0}</project>";

		[Test]
		public void EmptyPomTest()
		{
			var content = string.Format(ProjectTemplate, string.Empty);
			var document = XDocument.Parse(content, LoadOptions.PreserveWhitespace);

			var projectModel = new ProjectObjectModel(document);
			Assert.That(projectModel.RootElement.Value, Is.Empty);
		}

		[Test]
		public void ElementValueTest()
		{
			var content = string.Format(ProjectTemplate, "<p>abc</p>");
			var document = XDocument.Parse(content, LoadOptions.PreserveWhitespace);

			var projectModel = new ProjectObjectModel(document);
			Assert.That(projectModel.ReadElementValueOrNull("p"), Is.EqualTo("abc"));			
		}
	}
}