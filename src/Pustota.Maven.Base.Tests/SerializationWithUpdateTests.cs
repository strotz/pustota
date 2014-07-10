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

		const string EmptyProjectXml =
@"<?xml version=""1.0"" encoding=""us-ascii""?>
<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
</project>";

		[Test]
		public void UpdateEmptyProjectTest()
		{
			var project = _serializer.Deserialize(EmptyProjectXml);
			var updated = _serializer.Serialize(project, EmptyProjectXml);

			Assert.That(updated, Is.EqualTo(EmptyProjectXml));
		}

		[Test]
		public void XDeclarationFixTests()
		{
			var document = new XDocument(
				new XDeclaration("1.0", "us-ascii", null),
				new XElement(MavenSerialization.XmlNs + "project",
					new XAttribute("xmlns", MavenSerialization.XmlNs),
					new XAttribute(XNamespace.Xmlns + "xsi", MavenSerialization.Xsi),
					new XAttribute(MavenSerialization.Xsi + "schemaLocation", MavenSerialization.SchemaLocation)
				));

			using (var output = new UsAsciiStringWriter())
			{
				using (var xmlWriter = XmlWriter.Create(output))
				{
					document.WriteTo(xmlWriter);
				}

				Assert.That(output.ToString(), Is.StringStarting(@"<?xml version=""1.0"" encoding=""us-ascii""?>"));
			}
		}

	}
}