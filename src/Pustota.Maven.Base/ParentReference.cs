using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace Pustota.Maven.Base
{
	// REVIEW
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ParentReference :
		ProjectReferenceBase,
		IParentReference
	{
		[XmlElement("relativePath")]
		public string RelativePath { get; set; }

		internal string PossibleParentFullPath { get; private set; }

		public bool RelativePathDefined
		{
			get { return !string.IsNullOrEmpty(RelativePath); }
		}

		internal void ResolveRelativePath(string projectDirectoryName)
		{
			string normalizedRelativePath;
			if (RelativePathDefined)
			{
				normalizedRelativePath = RelativePath.Replace('/', Path.DirectorySeparatorChar);
			}
			else
			{
				const string projectFilePattern = "pom.xml"; // REVIEW move to Project as const
				normalizedRelativePath = Path.Combine("..", projectFilePattern); // default parent path
			}
			PossibleParentFullPath = Path.GetFullPath(Path.Combine(projectDirectoryName, normalizedRelativePath));
		}
	}
}
