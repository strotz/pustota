using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using Pustota.Maven.Serialization;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class SerializationWithUpdateTests
	{
		private IDataFactory _realDataFactory;
		private IProjectSerializerWithUpdate _serializer;

		[SetUp]
		public void Setup()
		{
			_realDataFactory = new DataFactory();
			_serializer = new ProjectSerializer(_realDataFactory);
		}

		[Test]
		public void UpdateEmptyProjectTest()
		{
			const string emptyProjectXml =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd""></project>";

			var project = _serializer.Deserialize(emptyProjectXml);
			var updated = _serializer.Serialize(project, emptyProjectXml);

			Assert.That(updated, Is.EqualTo(emptyProjectXml));
		}

		[Test]
		public void UpdateProjectWithCommentTest()
		{
			const string projectXml =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
	<!-- test -->
</project>";

			var project = _serializer.Deserialize(projectXml);
			var updated = _serializer.Serialize(project, projectXml);

			Assert.That(updated, Is.EqualTo(projectXml));
		}

		[Test]
		public void UpdateProjectWithModulesTest()
		{
			const string projectXml =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
	<!-- test -->
	<modules>
		<module>a</module>
		<module>b</module>
	</modules>
</project>";

			var project = _serializer.Deserialize(projectXml);
			var updated = _serializer.Serialize(project, projectXml);

			Assert.That(updated, Is.EqualTo(projectXml));
		}

		[Test]
		public void UpdateProjectWithPluginTest()
		{
			const string projectXml =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
	<build>
		<plugins>
			<plugin>
				<artifactId>maven-assembly-plugin</artifactId>
				<executions>
					<execution>
						<configuration>
							<descriptors>
								<descriptor>assembly.xml</descriptor>
							</descriptors>
						</configuration>
					</execution>
				</executions>
			</plugin>
		</plugins>
	</build>
</project>";

			var project = _serializer.Deserialize(projectXml);
			var updated = _serializer.Serialize(project, projectXml);

			Assert.That(updated, Is.EqualTo(projectXml));
		}

		[Test]
		public void UpdateChangedProjectTest()
		{
			const string projectXml =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
	<artifactId>a</artifactId>
</project>";

			var project = _serializer.Deserialize(projectXml);
			project.ArtifactId = "b";
			var updatedOnce = _serializer.Serialize(project, projectXml);

			project = _serializer.Deserialize(updatedOnce);
			project.ArtifactId = "a";
			var updatedTwice = _serializer.Serialize(project, updatedOnce);

			Assert.That(updatedTwice, Is.EqualTo(projectXml));
		}

		const string BuildWithTestResources =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
	<build>
		<testResources>
			<testResource>
				<directory>src/test/resources</directory>
				<filtering>false</filtering>
			</testResource>
		</testResources>
		<plugins>
			<plugin>
				<artifactId>maven-assembly-plugin</artifactId>
				<executions>
					<execution>
						<configuration>
							<descriptors>
								<descriptor>assembly.xml</descriptor>
							</descriptors>
						</configuration>
					</execution>
				</executions>
				<dependencies>
					<dependency>
						<groupId>ghyyejpkw0i</groupId>
						<artifactId>1m2xa54bkrv</artifactId>
						<version>41zyt5fjrjl</version>
					</dependency>
				</dependencies>
			</plugin>
		</plugins>
	</build>
</project>";

		[Test]
		public void TestResourcesDeserialization()
		{
			var deserialized = _serializer.Deserialize(BuildWithTestResources);
			string serialized = _serializer.Serialize(deserialized, BuildWithTestResources);

			Trace.WriteLine(serialized);

			Assert.That(serialized, Is.EqualTo(BuildWithTestResources));
		}

	}
}