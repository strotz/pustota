using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
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

		readonly XNamespace _ns = @"http://maven.apache.org/POM/4.0.0";

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

		private void ApplyToElement(object data, XElement parentElement)
		{
			foreach (PropertyInfo propertyInfo in GetPublicProperties(data))
			{
				Type propertyType = propertyInfo.PropertyType;

				XElement element = null;
				if (propertyType.IsPrimitive)
				{
					element = CreatePrimitiveElement(data, propertyInfo);
				}
				else if (propertyType == typeof(string))
				{
					element = CreatePrimitiveElement(data, propertyInfo);
				}
				else if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
				{
					throw new NotImplementedException("Nullable");
				}
				else if (typeof(IXmlSerializable).IsAssignableFrom(propertyType))
				{
					element = ProcessXmlSerializable(data, propertyInfo);
				}
				else if (typeof(ICollection).IsAssignableFrom(propertyType))
				{
					element = CreateCollection(data, propertyInfo);
				}
				else
				{
					element = CreateComplexElement(data, propertyInfo);
				}

				if (element != null)
				{
					parentElement.Add(element);
				}

				//if (intType.IsGenericType
            //&& intType.GetGenericTypeDefinition() == typeof(IEnumerable<>)) 

				//				else if propertyType.GetInterfaces().Any(
				//	propertyType.IsGenericType item => typeof(ICollection<>) == item.GetGenericTypeDefinition())
				//{
				//	Trace.WriteLine(" generic ICollection element");
				//	element = CreatePrimitiveElement(data, propertyInfo);
				//}
			}
		}

		private XElement CreatePrimitiveElement(object data, PropertyInfo propertyInfo)
		{
			if (!CheckShouldSerialize(data, propertyInfo.Name))
			{
				return null;
			}

			XName name = GetElementName(propertyInfo);

			object content = propertyInfo.GetGetMethod().Invoke(data, null);
			object defaultValue = GetElementDefaultValue(propertyInfo);
			if (Equals(content, defaultValue))
			{
				return null;
			}

			return new XElement(name, content);
		}

		private XElement CreateComplexElement(object data, PropertyInfo propertyInfo)
		{
			if (!CheckShouldSerialize(data, propertyInfo.Name))
			{
				return null;
			}

			XName name = GetElementName(propertyInfo);

			object content = propertyInfo.GetGetMethod().Invoke(data, null);
			object defaultValue = GetElementDefaultValue(propertyInfo);
			if (Equals(content, defaultValue))
			{
				return null;
			}

			var element = new XElement(name);
			ApplyToElement(content, element);
			return element;
		}

		private XElement CreateCollection(object data, PropertyInfo propertyInfo)
		{
			if (!CheckShouldSerialize(data, propertyInfo.Name))
			{
				return null;
			}

			XName name = GetCollectionName(propertyInfo);

			object content = propertyInfo.GetGetMethod().Invoke(data, null);
			if (Equals(content, null))
			{
				return null;
			}
			ICollection collection = content as ICollection;
			if (collection == null)
			{
				return null;
			}

			bool serializeNull = true;
			string itemName = "Item";
			XmlArrayItemAttribute attribute = propertyInfo.GetCustomAttribute<XmlArrayItemAttribute>();
			if (attribute != null)
			{
				serializeNull = attribute.IsNullable;
				itemName = attribute.ElementName;
			}

			var element = new XElement(name);

			foreach (var item in collection)
			{
				if (item == null)
				{
					if (serializeNull == true)
					{
						throw new NotImplementedException("IsNullable");
					}
				}
				else
				{
					var childElement = new XElement(_ns + itemName);
					ApplyToElement(item, childElement);
					element.Add(childElement);
				}
			}

			return element;
		}


		private XElement ProcessXmlSerializable(object data, PropertyInfo propertyInfo)
		{
			if (!CheckShouldSerialize(data, propertyInfo.Name))
			{
				return null;
			}

			XName name = GetElementName(propertyInfo);

			object content = propertyInfo.GetGetMethod().Invoke(data, null);
			object defaultValue = GetElementDefaultValue(propertyInfo);
			if (Equals(content, defaultValue))
			{
				return null;
			}

			var element = new XElement(name);

			throw new NotImplementedException("ProcessXmlSerializable");
			
			return element;
		}

		private XName GetCollectionName(PropertyInfo propertyInfo)
		{
			XmlArrayAttribute attribute = propertyInfo.GetCustomAttribute<XmlArrayAttribute>();
			if (attribute == null)
			{
				return _ns + propertyInfo.Name;
			}
			return _ns + attribute.ElementName;
		}

		private XName GetElementName(PropertyInfo propertyInfo)
		{
			XmlElementAttribute attribute = propertyInfo.GetCustomAttribute<XmlElementAttribute>();
			if (attribute == null)
			{
				return _ns + propertyInfo.Name;
			}
			return _ns + attribute.ElementName;
		}

		private object GetElementDefaultValue(PropertyInfo propertyInfo)
		{
			var attribute = propertyInfo.GetCustomAttribute<System.ComponentModel.DefaultValueAttribute>();
			if (attribute == null)
			{
				return GetDefaultValue(propertyInfo.PropertyType);
			}
			return attribute.Value;
		}

		private static object GetDefaultValue(Type t)
		{
			if (!t.IsValueType || Nullable.GetUnderlyingType(t) != null)
				return null;

			return Activator.CreateInstance(t);
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
