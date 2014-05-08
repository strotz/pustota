using System.Linq;
using Pustota.Maven.Editor.Models;

namespace Pustota.Maven.Editor.ViewModels
{
	internal class ProjectTypeMapService
	{
		// REVIEW: this is point of extensibility, hardcoded for now 
		private ProjectType ResolveType(Project project)
		{
			if (project.Parent != null)
			{
				switch (project.ArtifactId)
				{
					case "vcbuild":
					case "VcBuild":
						return ProjectType.CppProj;
					case "vctest":
					case "VcTest":
						return ProjectType.VcTest;
					case "csbuild":
						return ProjectType.CsBuild;
					case "CsAssembly":
					case "CsAnyCpuAssembly":
						return ProjectType.CsAssembly;
					case "CsPublic":
					case "CsAnyCpuPublic":
						return ProjectType.CsPublic;
					case "cstest":
					case "CsTestProject":
						return ProjectType.CsTestProject;
					case "wix":
					case "WixMsi":
					case "WixMsm":
						return ProjectType.WixProj;
					case "Passolo":
					case "Translation":
						return ProjectType.PassoloProj;
					case "binaries":
						return ProjectType.Binary;
					case "MavenPlugins":
						return ProjectType.MavenPlugins;
					case "root":
						return ProjectType.Root;
					case "uimicetest":
						return ProjectType.MiceTest;
					case "SuperPOM":
						return ProjectType.SuperPom;
				}
			}
			return project.Modules.Any() ? ProjectType.Group : ProjectType.None;
		}

		public string ResolveTypeName(Project project)
		{
			return ResolveType(project).ToString(); 
		}
	}
}