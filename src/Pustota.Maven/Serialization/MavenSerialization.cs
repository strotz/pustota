using System.Xml;
using System.Xml.Linq;

namespace Pustota.Maven.Serialization
{
	internal class MavenSerialization
	{
		internal const string DefaultNamespaceName = "pom";
		internal const string NamespaceName = DefaultNamespaceName;

		internal static readonly XNamespace XmlNs;
		internal static readonly XNamespace Xsi;
		internal static readonly XNamespace SchemaLocation;
		internal static readonly XmlNamespaceManager NsManager;

		static MavenSerialization()
		{
			XmlNs = XNamespace.Get(@"http://maven.apache.org/POM/4.0.0");
			Xsi = XNamespace.Get(@"http://www.w3.org/2001/XMLSchema-instance");
			SchemaLocation = XNamespace.Get(@"http://maven.apache.org/POM/4.0.0 http://maven.apache.org/maven-v4_0_0.xsd");

			NsManager = new XmlNamespaceManager(new NameTable());
			NsManager.AddNamespace(NamespaceName, XmlNs.NamespaceName);
		}
	}
}