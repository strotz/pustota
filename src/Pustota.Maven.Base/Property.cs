using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Pustota.Maven.Base
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class Property : 
		IProperty,
		IXmlSerializable
	{
		public string Name { get; set; }
		public string Value { get; set; }

		public override string ToString()
		{
			return string.Format("Property:{0}={1}", Name, Value);
		}

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			reader.MoveToContent();
			bool isEmptyElement = reader.IsEmptyElement;
			reader.ReadStartElement();
			if (isEmptyElement)
			{
				return;
			}
			Name = reader.Name;
			Value = reader.ReadElementString();
			reader.ReadEndElement();
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement(Name);
			writer.WriteValue(Value);
			writer.WriteEndElement();
		}
	}
}
