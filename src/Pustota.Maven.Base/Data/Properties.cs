using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	[SerializableAttribute]
	[System.Diagnostics.DebuggerStepThroughAttribute]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(AnonymousType = true, Namespace = "http://maven.apache.org/POM/4.0.0")]
	public class Properties
	{
		public Properties()
		{
			Items = new List<Property>();
		}

		[XmlAnyElement] // REVIEW: redo
		public List<Property> Items { get; set; }

		public bool Empty
		{
			get { return Items == null || Items.Count == 0; }
		}
	}
}