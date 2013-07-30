using System;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	public class Properties : IXmlSerializable
	{
		readonly string _ns = @"http://maven.apache.org/POM/4.0.0";

		public Properties()
		{
			Items = new List<Property>();
		}

		public List<Property> Items { get; set; }

		public bool Empty
		{
			get { return Items == null || Items.Count == 0; }
		}

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			reader.ReadStartElement("properties");

			bool isEmptyElement = reader.IsEmptyElement;
			if (isEmptyElement)
				return;

			while (!reader.EOF)
			{
				string name = reader.Name;
				if (name == "properties")
					break;
				if (name == "") // comment?
				{
					reader.Read();
					continue;
				}
				string value = reader.ReadElementString();
				Items.Add(new Property{Name = name, Value = value});
			}
			reader.ReadEndElement();
		}

		public void WriteXml(XmlWriter writer)
		{
			foreach (Property property in Items)
			{
				writer.WriteElementString(property.Name, _ns, property.Value);
			}
		}
	}
}