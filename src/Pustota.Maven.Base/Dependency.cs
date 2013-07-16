using System.ComponentModel;
using System.Xml.Serialization;

namespace Pustota.Maven.Base
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class Dependency : 
		ProjectReferenceBase,
		IDependency
	{
		[XmlElement("classifier")]
		public string Classifier { get; set; }

		[XmlElement("type")]
		public string Type { get; set; }

		[XmlElement("scope")]
		public string Scope { get; set; }

		[XmlElement("optional", IsNullable = true)]
		public bool? Optional { get; set; }

		public bool ShouldSerializeOptional()
		{
			return Optional.HasValue; 
		}
	}
}
