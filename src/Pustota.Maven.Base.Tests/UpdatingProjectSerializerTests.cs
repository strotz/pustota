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

	}
}
