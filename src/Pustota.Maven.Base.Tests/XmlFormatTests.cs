using System.CodeDom;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using Pustota.Maven.Serialization;

namespace Pustota.Maven.Base.Tests
{
	public class XmlFormatTests
	{
		public const string XmlHeader = @"<?xml version=""1.0"" encoding=""utf-8""?>
";

		private string ToMavenXml(XDocument document)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Encoding = new UTF8Encoding(false),
				Indent = true,
				IndentChars = "\t"
			};
			using (var output = new MemoryStream())
			{
				using (var xmlWriter = XmlWriter.Create(output, settings))
				{
					document.WriteTo(xmlWriter);
				}
				string result = Encoding.Default.GetString(output.ToArray());
				return result;
			}
		}

		[Test]
		public void XDeclarationFixTests()
		{
			var document = new XDocument(
				new XDeclaration("1.0", "utf-8", null),
				new XElement(MavenSerialization.XmlNs + "project",
					new XAttribute("xmlns", MavenSerialization.XmlNs),
					new XAttribute(XNamespace.Xmlns + "xsi", MavenSerialization.Xsi),
					new XAttribute(MavenSerialization.Xsi + "schemaLocation", MavenSerialization.SchemaLocation)
				));

			var output = ToMavenXml(document);
			Assert.That(output, Is.StringStarting(@"<?xml version=""1.0"" encoding=""utf-8""?>"));
		}

		[Test]
		public void NewLineFixTests()
		{
			var document = new XDocument(
				new XDeclaration("1.0", "us-ascii", null),
				new XElement(MavenSerialization.XmlNs + "project",
					new XAttribute("xmlns", MavenSerialization.XmlNs),
					new XAttribute(XNamespace.Xmlns + "xsi", MavenSerialization.Xsi),
					new XAttribute(MavenSerialization.Xsi + "schemaLocation", MavenSerialization.SchemaLocation)
				));

			const string projectXml =
XmlHeader + 
@"<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"" />";

			var output = ToMavenXml(document);
			Assert.That(output, Is.EqualTo(projectXml));
		}

		[Test]
		public void MultipleNewLineFixTests()
		{
			var document = new XDocument(
				new XDeclaration("1.0", "us-ascii", null),
				new XElement(MavenSerialization.XmlNs + "project",
					new XAttribute("xmlns", MavenSerialization.XmlNs),
					new XAttribute(XNamespace.Xmlns + "xsi", MavenSerialization.Xsi),
					new XAttribute(MavenSerialization.Xsi + "schemaLocation", MavenSerialization.SchemaLocation),
					new XElement(MavenSerialization.XmlNs + "module", "a"),
					new XElement(MavenSerialization.XmlNs + "module", "b")
				));

			const string projectXml =
XmlHeader + 
@"<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd"">
	<module>a</module>
	<module>b</module>
</project>";

			var output = ToMavenXml(document);
			Assert.That(output, Is.EqualTo(projectXml));
		}

		
	}
}