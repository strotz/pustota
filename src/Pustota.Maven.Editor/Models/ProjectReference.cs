using System.ComponentModel;
using Pustota.Maven.Editor.PomXml;

namespace Pustota.Maven.Editor.Models
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	internal class ProjectReference : IProjectReference
	{
		public string ArtifactId { get; set; }
		public string GroupId { get; set; }
		public string Version { get; set; }

		[Browsable(false)]
		public bool HasSpecificVersion
		{
			get
			{
				return !string.IsNullOrEmpty(Version);
			}
		}

		public string ProjectKey
		{
			get
			{
				return string.Format("{0}:{1} ({2})", GroupId, ArtifactId, Version);
			}
		}

		internal protected virtual void LoadFromElement(PomXmlElement element)
		{
			ArtifactId = element.ReadElementValue("artifactId");
			GroupId = element.ReadElementValue("groupId");
			Version = element.ReadElementValue("version");
		}

		internal protected virtual void SaveToElement(PomXmlElement element)
		{
			element.SetElementValue("groupId", GroupId);
			element.SetElementValue("artifactId", ArtifactId);
			element.SetElementValue("version", Version);
		}

		public override string ToString()
		{
			return ProjectKey;
		}
	}
}