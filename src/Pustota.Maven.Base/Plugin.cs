using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Pustota.Maven.Base
{
	public class Plugin : 
		ParentReference,
		IPlugin
	{
		public Plugin()
		{
			Dependencies = new List<Dependency>();
		}

		[XmlElement("extensions", IsNullable = true)]
		public bool? Extensions { get; set; }

		public bool ShouldSerializeExtensions()
		{
			return Extensions.HasValue;
		}

		[XmlElement("inherited", IsNullable = true)]
		public bool? Inherited { get; set; }

		public bool ShouldSerializeInherited()
		{
			return Inherited.HasValue;
		}

		[XmlAnyElement("executions")]
		public XmlElement Executions { get; set; }

		[XmlAnyElement("configuration")]
		public XmlElement Configuration { get; set; }

		[XmlArray("dependencies")]
		[XmlArrayItem("dependency")]
		public List<Dependency> Dependencies { get; set; }

		public bool ShouldSerializeDependencies()
		{
			return Dependencies != null && Dependencies.Count != 0;
		}
	}
}
