using System.ComponentModel;
using Pustota.Maven.Editor.Models;
using Pustota.Maven.Editor.PomXml;
using Pustota.Maven.Editor.Validations;

namespace Pustota.Maven.Editor.Externals
{
	class ExternalModule : 
		ProjectReference,
		IFixable
	{
		public string FullPath { get; private set; }

		[Browsable(false)]
		public bool Changed { get; set; }

		public ExternalModule(IProjectReference reference, string path)
		{
			ArtifactId = reference.ArtifactId;
			GroupId = reference.GroupId;
			Version = reference.Version;
			FullPath = path;
		}

		public ExternalModule(string groupId, string artifactId, string version, string path)
		{
			ArtifactId = artifactId;
			GroupId = groupId;
			Version = version;
			FullPath = path;
		}

		public ExternalModule()
		{
			ArtifactId = string.Empty;
			GroupId = string.Empty;
			Version = string.Empty;
			FullPath = string.Empty;
		}

		public string Title
		{
			get
			{
				return string.Format("External module: {0}", base.ToString());
			}
		}

		public override string ToString()
		{
			return Title;
		}

		public void SaveTo(PomXmlElement externalModuleNode)
		{
			externalModuleNode.SetElementValue("artifactId", ArtifactId);
			externalModuleNode.SetElementValue("groupId", GroupId);
			externalModuleNode.SetElementValue("version", Version);
		}
	}
}
