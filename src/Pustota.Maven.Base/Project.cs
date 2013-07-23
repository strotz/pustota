using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Pustota.Maven.Base
{
	//[XmlRoot("project", Namespace = "http://maven.apache.org/POM/4.0.0", IsNullable = false)]
	//public class Project :
	//	ProjectReferenceBase
	//	// IProject
	//{

	//	public Project()
	//	{
	//		Properties = new List<Property>();
	//		Dependencies = new List<Dependency>();
	//	}
	//}

	// internal const string ProjectFilePattern = "pom.xml";
	// public PomXmlDocument Pom { get; private set; }
	/*
			private readonly string _directoryName;
 		// public string FullPath { get; set; }
	 * 
			public IEnumerable<IDependency> AllDependencies
			{
				get
				{
					return Dependencies.Concat(Profiles.SelectMany(p => p.Dependencies));
				}
			}

			public IEnumerable<IProperty> AllProperties
			{
				get
				{
					return Properties.Concat(Profiles.SelectMany(p => p.Properties));
				}
			}
			public IEnumerable<IModule> AllModules
			{
				get
				{
					return Modules.Concat(Profiles.SelectMany(p => p.Modules));
				}
			}
		
			internal string CalculatedVersion { get; private set; }


			public Project(string fileName) : 
				this()
			{
				FullPath = Path.GetFullPath(fileName);

				_directoryName = Path.GetDirectoryName(FullPath);
				if (_directoryName == null)
				{
					throw new InvalidOperationException("DirectoryName for the project cannot be null");
				}

				CalculatedVersion = Version;
			}

			internal string GetModulePath(IModule module)
			{
				return Path.Combine(Path.Combine(_directoryName, module.Path), ProjectFilePattern);
			}

			internal IEnumerable<IProject> LoadProjectsTree()
			{
				Queue<Project> queue = new Queue<Project>();
				queue.Enqueue(this);

				while (queue.Count != 0)
				{
					Project project = queue.Dequeue();
					yield return project;

					foreach (var module in project.AllModules)
					{
						string modulePath = project.GetModulePath(module);
						if (File.Exists(modulePath))
						{
							queue.Enqueue(new Project(modulePath));
						}
						else
						{
							// TODO: Log it to console 
						}
					}
				}
			}

			internal string DirectoryName 
			{
				get { return _directoryName; }
			}

			internal void CalculateVersion(IEnumerable<IProject> allProjects)
			{
				if (!HasSpecificVersion) // deal with projects without version
				{
					CalculatedVersion = new ProjectBrowser(allProjects).GetInheritedVersion(project);
				}	
			}

			public void Save()
			{
				if (File.Exists(FullPath))
					LoadXml();
				else
				{
					CreateXML();
				}
				AdjustXml();
				Pom.SaveTo(FullPath);
				if (_assembly != null)
					_assembly.Save();
				Changed = false;
			}

			public void CreateXML()
			{
				Pom = new PomXmlDocument(Type);
				AdjustXml();
				//Pom.SaveTo(path);
				Changed = true;
			}

			public void Edit(string text)
			{
				PomXmlDocument pomXmlDocument;
				if (!PomXmlDocument.TryParse(text, out pomXmlDocument))
				{
					throw new ArgumentException("XML Parsing Error: not well-formed");
				}
				Pom = pomXmlDocument;
			}

			public void AddModule(Module newModule)
			{
				if (Modules.All(m => m.Path != newModule.Path))
				{
					Modules.Add(newModule);
					Changed = true;
				}
			}
			*/
}
