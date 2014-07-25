using System.ComponentModel;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Externals
{
	internal class ExternalModule : 
		ProjectReference,
		IExternalModule
		// IFixable
	{
		//[Browsable(false)]
		//public bool Changed { get; set; }

		internal ExternalModule()
		{
		}

		//public ExternalModule(IProjectReference reference, string path)
		//{
		//	ArtifactId = reference.ArtifactId;
		//	GroupId = reference.GroupId;
		//	Version = reference.Version;
		//}

		//public ExternalModule(string groupId, string artifactId, string version, string path)
		//{
		//	ArtifactId = artifactId;
		//	GroupId = groupId;
		//	Version = version;
		//}

		public override string ToString()
		{
			return Title;
		}

		private string Title
		{
			get
			{
				return string.Format("External module: {0}", base.ToString());
			}
		}

		//public void SaveTo(PomXmlElement externalModuleNode)
		//{
		//	externalModuleNode.SetElementValue("artifactId", ArtifactId);
		//	externalModuleNode.SetElementValue("groupId", GroupId);
		//	externalModuleNode.SetElementValue("version", Version);
		//}
	}
}
