using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Pustota.Maven.Base.Data;

namespace Pustota.Maven.Base.Serialization
{
	public class UpdatingProjectSerializer : IProjectSerializerWithUpdate
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
			return UpdateContent(project, string.Empty);
		}

		public string UpdateContent(Project project, string content)
		{
			ProjectXmlDocument document;

			if (string.IsNullOrEmpty(content))
			{
				document = new ProjectXmlDocument();
			}
			else
			{
				document = ProjectXmlDocument.Load(content);
			}

			ApplyToElement(project, document.Root);

			return document.ToString();
		}

		private void ApplyToElement(object data, XElement element)
		{
			foreach (var propertyInfo in GetPublicProperties(data))
			{
				Trace.Write(propertyInfo.Name);
				if (!CheckShouldSerialize(data, propertyInfo.Name))
				{
					Trace.WriteLine(" skip");
					continue;
				}
			}

			// remove null and default values
			// apply attributes
			// split simple
			// process simple and collections
			// (run recursively for complex) 
			// process ISerializable ?
		}

		private static IEnumerable<PropertyInfo> GetPublicProperties(object data)
		{
			return
				data.
					GetType().
					GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).
					Where(pi => pi.CanRead && pi.CanWrite);
		}

		private static bool CheckShouldSerialize(object data, string propertyName)
		{
			string name = "ShouldSerialize" + propertyName;
			var methodInfo = data.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			if (methodInfo == null)
			{
				return true;
			}
			return (bool) methodInfo.Invoke(data, null);
		}
	}
}
