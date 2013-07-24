using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Pustota.Maven.Base.Data;

namespace Pustota.Maven.Base.Serialization
{
	public class UpdatingProjectSerializer : IProjectSerializerWithUpdate
	{
		private readonly XmlSerializer _serializer = new XmlSerializer(typeof(Project), "http://maven.apache.org/POM/4.0.0");

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
				return (Project)_serializer.Deserialize(textReader);
			}
		}

		public string Serialize(Project project)
		{
			throw new NotImplementedException();
		}

		public string UpdateContent(Project project, string content)
		{
			throw new NotImplementedException();
		}
	}
}
