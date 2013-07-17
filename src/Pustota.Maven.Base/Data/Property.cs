using System.Xml;

namespace Pustota.Maven.Base.Data
{
	public class Property : XmlElement 
	{
		public Property() 
			:base("x", "y", "z", null)
		{
			
		}

		public Property(string prefix, string localName, string namespaceURI, XmlDocument doc)
			: base(prefix, localName, namespaceURI, doc)
		{
		}

		public string PropertyName
		{
			get { return Name; }
			set { this.Value = value; }
		}

		public string PropertyValue
		{
			get { throw new System.NotImplementedException(); }
			set { this.InnerText = value; }
		}

		public override string ToString()
		{
			return string.Format("Property:{0}={1}", Name, Value);
		}
	}
}
