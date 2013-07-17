using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Pustota.Maven.Base.Data;

namespace Pustota.Maven.Base.Serialization
{
	public class ProjectSerializer : IProjectSerializer
	{
		private readonly XmlSerializer _serializer = new XmlSerializer(typeof (Project), "http://maven.apache.org/POM/4.0.0");

		private readonly XmlSerializerNamespaces _namespace = new XmlSerializerNamespaces(
			new XmlQualifiedName[]
			{
				new XmlQualifiedName("", "http://maven.apache.org/POM/4.0.0"), 	
				new XmlQualifiedName("xsi", "http://www.w3.org/2001/XMLSchema-instance")
			});

		public Project Deserialize(string content)
		{
			using (var textReader = new StringReader(content))
			{
				return (Project) _serializer.Deserialize(textReader);
			}
		}

		public string Serialize(Project project)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				IndentChars = "\t",
				Indent = true
			};

			using (MemoryStream memory = new MemoryStream())
			{
				using (StreamWriter writer = new StreamWriter(memory, Encoding.ASCII))
				{
					using (XmlTextWriter xmlWriter = new XmlTextWriter(writer))
					{
						xmlWriter.Formatting = Formatting.Indented;
						xmlWriter.Indentation = 1;
						xmlWriter.IndentChar = '\x09';
						_serializer.Serialize(xmlWriter, project, _namespace);

						using (StreamReader reader = new StreamReader(memory))
						{
							memory.Position = 0;
							return reader.ReadToEnd();
						}
					}
				}
			}
			/*

			StringBuilder output = new StringBuilder();
			var settings = new XmlWriterSettings
			{
				Encoding = Encoding.ASCII,
				OmitXmlDeclaration = false
			};
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces(); 
			ns.Add("", "");
			using (XmlWriter writer = XmlWriter.Create(output, settings))
			{
				_serializer.Serialize(writer, project, ns);
			}
			var textWriter = new StringWriter();
			textWriter.Encoding = Encoding.ASCII;
			return textWriter.ToString();
			return output.ToString();
			 */
		}
	}
}
