using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using Pustota.Maven.Base.Data;
using Pustota.Maven.Base.Serialization;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class UpdatingProjectSerializerTests
	{
		private IProjectSerializerWithUpdate _serializer;

		const string emptyProjectXml =
	@"<?xml version=""1.0"" encoding=""us-ascii""?>
<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
</project>";

		[SetUp]
		public void Setup()
		{
			_serializer = new UpdatingProjectSerializer();
		}

		[Test]
		public void EmptyProjectSerializationTest()
		{
			const string absolutellyEmptyProjectXml =
	@"<?xml version=""1.0"" encoding=""us-ascii""?>
<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"" />";

			Project project = new Project();
			string serialized = _serializer.Serialize(project);
			Assert.That(serialized, Is.EqualTo(absolutellyEmptyProjectXml));
		}

		[Test]
		public void UpdateEmptyProjectTest()
		{
			Project project = new Project();
			string serialized = _serializer.UpdateContent(project, emptyProjectXml);
			Assert.That(serialized, Is.EqualTo(emptyProjectXml));
		}

		[Test]
		public void UpdateNotEmptyProjectTest()
		{
			Project project = new Project();
			project.ArtifactId = "test";
			string serialized = _serializer.UpdateContent(project, emptyProjectXml);
			Assert.That(serialized, Is.Not.EqualTo(emptyProjectXml));
		}

		[Test]
		public void SinglePropertyTest()
		{
			const string PropertiesProjectEmptyXml =
@"<?xml version=""1.0"" encoding=""us-ascii""?>
<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
	<properties>
		<a>asdas</a>
	</properties>
</project>";

			Project deserialized = _serializer.Deserialize(PropertiesProjectEmptyXml);
			string serialized = _serializer.Serialize(deserialized);

			Assert.That(serialized, Is.EqualTo(PropertiesProjectEmptyXml));
		}

		public XName GetElementName(string name)
		{
			XNamespace ns = @"http://maven.apache.org/POM/4.0.0";
			return ns + name;
		}

		[Test]
		public void ArtifactNotEmptyProjectTest()
		{
			const string val = "test";
			Project project = new Project();
			project.ArtifactId = val;
			string serialized = _serializer.UpdateContent(project, emptyProjectXml);

			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
			var artifactElement = projectElement.Element(GetElementName("artifactId"));
			Assert.That(artifactElement.Value, Is.EqualTo(val));
		}

		[Test]
		public void EqualsTest()
		{
			object a1 = "a";
			object a2 = "a";

			if (a1 == a2)
			{
				
			}
			else
			{
				Assert.Fail("String compare not called");
			}
		}
	}
}
