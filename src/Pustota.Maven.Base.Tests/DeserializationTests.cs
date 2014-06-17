using System.IO;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace Pustota.Maven.Base.Tests
{
	[TestFixture]
	public class DeserializationTests
	{
//		private IProjectSerializer _serializer;

//		const string EmptyProjectXml =
//@"<?xml version=""1.0"" encoding=""us-ascii""?>
//<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
//</project>";
		
//		public static string GetRandomString()     
//		{         
//			string path = Path.GetRandomFileName();         
//			path = path.Replace(".", ""); 
//			// Remove period.         
//			return path;     
//		}

//		public XName GetElementName(string name)
//		{
//			XNamespace ns = @"http://maven.apache.org/POM/4.0.0";
//			return ns + name;
//		}

//		public XName E(string name)
//		{
//			return GetElementName(name);
//		}

//		[SetUp]
//		public void Setup()
//		{
//			_serializer = new UpdatingProjectSerializer();
//		}

//		[Test]
//		public void EmptyProjectDeserializationTest()
//		{
//			Project project = _serializer.Deserialize(EmptyProjectXml);
//			Assert.That(project, Is.Not.Null);
//		}

//		[Test]
//		public void EmptyProjectSerializationTest()
//		{
//			Project project = new Project();
//			string serialized = _serializer.Serialize(project);

//			var origin = XDocument.Parse(EmptyProjectXml).Element(GetElementName( "project"));
//			var result = XDocument.Parse(serialized).Element(GetElementName("project"));

//			Assert.That(origin, Is.Not.Null);
//			Assert.That(result, Is.Not.Null);

//			foreach (var attribute in origin.Attributes())
//			{
//				var resultAttribute = result.Attribute(attribute.Name);
//				Assert.That(resultAttribute, Is.Not.Null);
//				Assert.That(resultAttribute.Value, Is.EqualTo(attribute.Value));
//			}
//		}

//		[Test]
//		public void ProjectIdentificationSerialization()
//		{
//			Project project = new Project
//			{
//				ArtifactId = GetRandomString(),
//				GroupId = GetRandomString(),
//				Version = GetRandomString()
//			};
//			string serialized = _serializer.Serialize(project);
//			Project deserialized = _serializer.Deserialize(serialized);

//			Assert.That(deserialized.ArtifactId, Is.EqualTo(project.ArtifactId));
//			Assert.That(deserialized.GroupId, Is.EqualTo(project.GroupId));
//			Assert.That(deserialized.Version, Is.EqualTo(project.Version));
//		}

//		[Test]
//		public void EmptyProjectSerialize()
//		{
//			var project = new Project();
//			string serialized = _serializer.Serialize(project);
//			var document = XDocument.Parse(serialized);
//			var projectElement = document.Descendants(E("project")).Single();
//			Assert.That(projectElement.HasElements, Is.False);
//		}

//		[Test]
//		public void TagNameTest()
//		{
//			Project project = new Project
//			{
//				ArtifactId = GetRandomString(),
//				GroupId = GetRandomString(),
//				Version = GetRandomString()
//			};
//			string serialized = _serializer.Serialize(project);

//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));

//			var artifactElement = projectElement.Element(GetElementName("artifactId"));
//			Assert.That(artifactElement, Is.Not.Null, "artifactId is missing");
	
//			var groupElement = projectElement.Element(GetElementName("groupId"));
//			Assert.That(groupElement, Is.Not.Null, "groupId is missing");
			
//			var versionElement = projectElement.Element(GetElementName("version"));
//			Assert.That(versionElement, Is.Not.Null, "version is missing");
//		}

//		[Test]
//		public void MoreProjectSimpleProperties()
//		{
//			Project project = new Project
//			{
//				Name = GetRandomString(),
//				Packaging = GetRandomString(),
//				ModelVersion = GetRandomString(),
//			};
//			string serialized = _serializer.Serialize(project);
//			Project deserialized = _serializer.Deserialize(serialized);

//			Assert.That(deserialized.Name, Is.EqualTo(project.Name));
//			Assert.That(deserialized.Packaging, Is.EqualTo(project.Packaging));
//			Assert.That(deserialized.ModelVersion, Is.EqualTo(project.ModelVersion));

//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));

//			Assert.That(projectElement.Element(GetElementName("name")), Is.Not.Null, "name");
//			Assert.That(projectElement.Element(GetElementName("packaging")), Is.Not.Null, "packaging");
//			Assert.That(projectElement.Element(GetElementName("modelVersion")), Is.Not.Null, "modelVersion");
//		}

//		[Test]
//		public void NameCanBeOmited()
//		{
//			var project = new Project();
//			string serialized = _serializer.Serialize(project);
//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
//			var nameElement = projectElement.Element(GetElementName("name"));
//			Assert.That(nameElement, Is.Null);
//		}

//		[Test]
//		public void ParentSerializationTest()
//		{
//			var project = new Project();
//			project.Parent = new Parent
//			{
//				ArtifactId = GetRandomString()
//			};
//			string serialized = _serializer.Serialize(project);
//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
//			var parentElement = projectElement.Element(GetElementName("parent"));
//			Assert.That(parentElement, Is.Not.Null, "parent is missing");

//			Assert.That(parentElement.Element(GetElementName("artifactId")), Is.Not.Null, "parent:artifactId");
//		}

//		[Test]
//		public void ParentSerializationPathTest()
//		{
//			var project = new Project();
//			project.Parent = new Parent
//			{
//				RelativePath = GetRandomString()
//			};
//			string serialized = _serializer.Serialize(project);
//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
//			var parentElement = projectElement.Element(GetElementName("parent"));
//			Assert.That(parentElement, Is.Not.Null, "parent is missing");
//			Assert.That(parentElement.Element(GetElementName("relativePath")), Is.Not.Null, "parent:relativePath");

//			Project deserialized = _serializer.Deserialize(serialized);
//			Assert.That(deserialized.Parent.RelativePath, Is.EqualTo(project.Parent.RelativePath));
//		}

//		[Test]
//		public void ModulesSerializationTest()
//		{
//			var project = new Project();
//			project.Modules.Add(new Module { Path = GetRandomString()});
//			string serialized = _serializer.Serialize(project);

//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
//			var modules = projectElement.Element(GetElementName("modules"));
//			Assert.That(modules, Is.Not.Null, "modules");

//			var module = modules.Element(GetElementName("module")); 
//			Assert.That(module, Is.Not.Null, "module");

//			Assert.IsFalse(module.HasElements);
//			Assert.That(module.Value, Is.EqualTo(project.Modules[0].Path));
//		}


//		[Test]
//		public void MultiModulesTest()
//		{
//			var project = new Project();
//			project.Modules.Add(new Module { Path = GetRandomString() });
//			project.Modules.Add(new Module { Path = GetRandomString() });
//			project.Modules.Add(new Module { Path = GetRandomString() });
//			project.Modules.Add(new Module { Path = GetRandomString() });
//			string serialized = _serializer.Serialize(project);
//			Project deserialized = _serializer.Deserialize(serialized);

//			foreach (var module in project.Modules)
//			{
//				Assert.IsNotNull(deserialized.Modules.Single(item => item.Path == module.Path));
//			}
//		}

//		[Test]
//		public void PropertySerializationTest()
//		{
//			var project = new Project();
//			var property = new Property
//			{
//				Name = "a" + GetRandomString(),
//				Value = GetRandomString()
//			};
//			project.Properties.Items.Add(property);
//			string serialized = _serializer.Serialize(project);

//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
//			var properties = projectElement.Element(GetElementName("properties"));
//			var propertyElement = properties.Elements().First();
//			Assert.That(propertyElement.Name, Is.EqualTo(GetElementName(property.Name)), "name");
//			Assert.That(propertyElement.Value, Is.EqualTo(property.Value), "value");
//		}

//		[Test]
//		public void PropertyDeserializationTest()
//		{
//			var project = new Project();
//			var property = new Property
//			{
//				Name = "a" + GetRandomString(),
//				Value = GetRandomString()
//			};
//			project.Properties.Items.Add(property);
//			string serialized = _serializer.Serialize(project);
//			Project deserialized = _serializer.Deserialize(serialized);
//			var obtained = deserialized.Properties.Items.First();
//			Assert.That(obtained.Name, Is.EqualTo(property.Name));
//			Assert.That(obtained.Value, Is.EqualTo(property.Value));
//		}


//		[Test]
//		public void PropertyDeserializationTest2()
//		{
//			const string PropertiesProjectXml =
//@"<?xml version=""1.0"" encoding=""us-ascii""?>
//<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
//<properties>
//<a>aval</a>
//<b>bval</b>
//</properties>
//</project>";

//			Project deserialized = _serializer.Deserialize(PropertiesProjectXml);
			
//			Assert.That(deserialized.Properties.Items.Count, Is.EqualTo(2));

//			var first = deserialized.Properties.Items.First();
//			Assert.That(first.Name, Is.EqualTo("a"));
//			Assert.That(first.Value, Is.EqualTo("aval"));

//			var last = deserialized.Properties.Items.Last();
//			Assert.That(last.Name, Is.EqualTo("b"));
//			Assert.That(last.Value, Is.EqualTo("bval"));
//		}

//		[Test]
//		public void EmptyPropertyTest()
//		{
//			const string PropertiesProjectEmptyXml =
//@"<?xml version=""1.0"" encoding=""us-ascii""?>
//<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
//<properties>
//</properties>
//</project>";

//			Project deserialized = _serializer.Deserialize(PropertiesProjectEmptyXml);
//		}

//		[Test]
//		public void SinglePropertyTest()
//		{
//			const string PropertiesProjectEmptyXml =
//@"<?xml version=""1.0"" encoding=""us-ascii""?>
//<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
//<properties>
//<a>asdas</a>
//</properties>
//</project>";

//			Project deserialized = _serializer.Deserialize(PropertiesProjectEmptyXml);
//		}

//		[Test]
//		public void SingleAndCommentPropertyTest()
//		{
//			const string PropertiesProjectEmptyXml =
//@"<?xml version=""1.0"" encoding=""us-ascii""?>
//<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
//<properties>
//	<a>asdas</a>
//	<!-- <target.platform>m2e-wtp-e36</target.platform> -->
//</properties>
//</project>";

//			Project deserialized = _serializer.Deserialize(PropertiesProjectEmptyXml);
//		}

//		[Test]
//		public void DoubleAndCommentPropertyTest()
//		{
//			const string PropertiesProjectEmptyXml =
//@"<?xml version=""1.0"" encoding=""us-ascii""?>
//<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
//<properties>
//	<a>asdas</a>
//	<!-- <target.platform>m2e-wtp-e36</target.platform> -->
//	<a>asdas</a>
//</properties>
//</project>";

//			Project deserialized = _serializer.Deserialize(PropertiesProjectEmptyXml);
//			Assert.That(deserialized.Properties.Items.Count, Is.EqualTo(2));
//		}



//		[Test]
//		public void ManyPropertyTest()
//		{
//			var project = new Project();
//			project.Properties.Items.Add(new Property { Name = "a" + GetRandomString(), Value = GetRandomString() });
//			project.Properties.Items.Add(new Property { Name = "a" + GetRandomString(), Value = GetRandomString() });
//			project.Properties.Items.Add(new Property { Name = "a" + GetRandomString(), Value = GetRandomString() });
//			project.Properties.Items.Add(new Property { Name = "a" + GetRandomString(), Value = GetRandomString() });
//			string serialized = _serializer.Serialize(project);

//			Project deserialized = _serializer.Deserialize(serialized);

//			foreach (Property property in project.Properties.Items)
//			{
//				Assert.IsNotNull(deserialized.Properties.Items.Single(item => item.Name == property.Name && item.Value == property.Value));
//			}
//		}

//		[Test]
//		public void DependencyTest()
//		{
//			var project = new Project();
//			project.Dependencies.Add(new Dependency());
//			string serialized = _serializer.Serialize(project);
//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
//			var dependencies = projectElement.Element(GetElementName("dependencies"));
//			Assert.That(dependencies, Is.Not.Null);
//			var dependency = dependencies.Element(GetElementName("dependency"));
//			Assert.That(dependency, Is.Not.Null);
//		}

//		[Test]
//		public void DependencyOptionalTest()
//		{
//			var project = new Project();
//			project.Dependencies.Add(new Dependency() {Optional = true});
//			string serialized = _serializer.Serialize(project);
//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
//			var dependencies = projectElement.Element(GetElementName("dependencies"));
//			var dependency = dependencies.Element(GetElementName("dependency"));
//			Assert.That(dependency.Element(GetElementName("optional")), Is.Not.Null);
//		}

//		[Test]
//		public void DependencyOptionalOmitTest()
//		{
//			var project = new Project();
//			project.Dependencies.Add(new Dependency());
//			string serialized = _serializer.Serialize(project);
//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
//			var dependencies = projectElement.Element(GetElementName("dependencies"));
//			var dependency = dependencies.Element(GetElementName("dependency"));
//			Assert.That(dependency.Element(GetElementName("optional")), Is.Null);
//		}

//		[Test]
//		public void ProfileBasicSerialization()
//		{
//			var project = new Project();
//			project.Profiles.Add(new Profile());
//			string serialized = _serializer.Serialize(project);
//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
//			var profiles = projectElement.Element(GetElementName("profiles"));
//			var profile = profiles.Element(GetElementName("profile"));
//			Assert.That(profile, Is.Not.Null);
//		}

//		const string ProjectWithProfileXml =
//@"<?xml version=""1.0"" encoding=""us-ascii""?>
//<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
//<profiles>
//<profile>
//<id></id>
//<activation>
//        <activeByDefault>false</activeByDefault>
//        <jdk>1.5</jdk>
//        <os>
//          <name>Windows XP</name>
//          <family>Windows</family>
//          <arch>x86</arch>
//          <version>5.1.2600</version>
//        </os>
//        <property>
//          <name>sparrow-type</name>
//          <value>African</value>
//        </property>
//        <file>
//          <exists>${basedir}/file2.properties</exists>
//          <missing>${basedir}/file1.properties</missing>
//        </file>
//      </activation>
//</profile>
//</profiles>
//</project>";

//		[Test]
//		public void ProfileActivationDeserialization()
//		{
//			var deserialized = _serializer.Deserialize(ProjectWithProfileXml);
//			Assert.That(deserialized.Profiles.First().Activation, Is.Not.Null);
//		}

//		[Test]
//		public void ProfileModulesDependeciesPropertiesTest()
//		{
//			var project = new Project();
//			var profile = new Profile();
//			profile.Modules.Add(new Module {Path = GetRandomString()});
//			profile.Dependencies.Add(new Dependency {ArtifactId = GetRandomString()});
//			profile.Properties.Items.Add(new Property() { Name = "a" + GetRandomString(), Value = GetRandomString() });
//			project.Profiles.Add(profile);
//			string serialized = _serializer.Serialize(project);
//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
//			var profiles = projectElement.Element(GetElementName("profiles"));
//			var profileElement = profiles.Element(GetElementName("profile"));
//			Assert.That(profileElement, Is.Not.Null);
//			Assert.That(profileElement.Element(GetElementName("modules")).Element(GetElementName("module")).Value, 
//				Is.EqualTo(profile.Modules.First().Path));
//		}

//		[Test]
//		public void BuildSerializationTest()
//		{
//			var project = new Project();
//			var plugin = new Plugin();
//			project.EnableBuild();
//			project.Build.Plugins.Add(plugin);
//			string serialized = _serializer.Serialize(project);

//			var projectElement = XDocument.Parse(serialized).Element(GetElementName("project"));
//			var buildElement = projectElement.Element(GetElementName("build"));
//			Assert.IsNotNull(buildElement);
//		}

//		[Test]
//		public void PluginEmptySerialization()
//		{
//			var project = new Project();
//			var plugin = new Plugin
//			{
//			};
//			project.EnableBuild();
//			project.Build.Plugins.Add(plugin);
//			string serialized = _serializer.Serialize(project);

//			var document = XDocument.Parse(serialized);
//			var pluginElement = document.Descendants(E("plugin")).Single();
//			Assert.IsNotNull(pluginElement);
//			Assert.That(pluginElement.HasElements, Is.False);
//			Assert.That(pluginElement.HasAttributes, Is.False);
//		}

//		[Test]
//		public void PluginSerializationTest()
//		{
//			var project = new Project();
//			var plugin = new Plugin
//			{
//				ArtifactId = GetRandomString(),
//				GroupId = GetRandomString(),
//				Version = GetRandomString(),
//				Extensions = true,
//				Inherited = "false"
//			};
//			project.EnableBuild();
//			project.Build.Plugins.Add(plugin);

//			string serialized = _serializer.Serialize(project);

//			var document = XDocument.Parse(serialized);
//			var pluginElement = document.Descendants(E("plugin")).Single();
//			Assert.IsNotNull(pluginElement);
//			Assert.That(pluginElement.Element(E("artifactId")).Value, Is.EqualTo(plugin.ArtifactId));
//			Assert.That(pluginElement.Element(E("extensions")).Value, Is.EqualTo("true"));
//			Assert.That(pluginElement.Element(E("inherited")).Value, Is.EqualTo("false"));
//		}

//		const string PluginWithExecution =
//@"<?xml version=""1.0"" encoding=""us-ascii""?>
//<project xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"" xmlns=""http://maven.apache.org/POM/4.0.0"">
//	<modules />
//	<dependencies />
//	<profiles />
//	<build>
//		<plugins>
//			<plugin>
//				<artifactId>1m2xa54bkrv</artifactId>
//				<groupId>ghyyejpkw0i</groupId>
//				<version>41zyt5fjrjl</version>
//				<executions>...</executions>
//				<configuration>...</configuration>
//				<dependencies>
//					<dependency>
//						<artifactId>1m2xa54bkrv</artifactId>
//						<groupId>ghyyejpkw0i</groupId>
//						<version>41zyt5fjrjl</version>
//					</dependency>
//				</dependencies>
//			</plugin>
//		</plugins>
//	</build>
//</project>";

//		[Test]
//		public void PluginExecutionDeserialization()
//		{
//			var deserialized = _serializer.Deserialize(PluginWithExecution);

//			Assert.That(deserialized.Build.Plugins.Single().Executions, Is.Not.Null);
//			Assert.That(deserialized.Build.Plugins.Single().Configuration, Is.Not.Null);
//			Assert.That(deserialized.Build.Plugins.Single().Dependencies, Is.Not.Null);
//		}

//		[Test]
//		public void PluginManagementSerializationTest()
//		{
//			var project = new Project();
//			var plugin = new Plugin();
//			project.EnableBuild();
//			project.Build.PluginManagement.Plugins.Add(plugin);

//			string serialized = _serializer.Serialize(project);

//			var document = XDocument.Parse(serialized);
//			var pluginManagementElement = document.Descendants(E("pluginManagement")).Single();
//			var pluginElement = pluginManagementElement.Elements().SingleOrDefault();

//			Assert.That(pluginElement, Is.Not.Null);
//		}
	}
}
