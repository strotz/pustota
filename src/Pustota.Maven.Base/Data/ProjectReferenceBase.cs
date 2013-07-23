using System.Xml.Serialization;

namespace Pustota.Maven.Base.Data
{
	public interface IProjectReference
	{
		[XmlElement("artifactId")]
		string ArtifactId { get; set; }

		[XmlElement("groupId")]
		string GroupId { get; set; }

		[XmlElement("version")]
		string Version { get; set; }

		bool HasSpecificVersion { get; }
	}

	public abstract class ProjectReferenceBase : IProjectReference
	{
		[XmlElement("artifactId")]
		public string ArtifactId { get; set; }

		[XmlElement("groupId")]
		public string GroupId { get; set; }

		[XmlElement("version")]
		public string Version { get; set; }

		public bool HasSpecificVersion
		{
			get { return !string.IsNullOrEmpty(Version); }
		}

		public override string ToString()
		{
			return string.Format("{0}:{1} ({2})", GroupId, ArtifactId, Version);
		}
	}
}