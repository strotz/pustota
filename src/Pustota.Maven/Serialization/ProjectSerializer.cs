using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Pustota.Maven.Models;
using Pustota.Maven.Serialization.Data;

namespace Pustota.Maven.Serialization
{
	public interface IProjectSerializer
	{
		IProject Deserialize(string content);
		string Serialize(IProject project);
	}

	internal class ProjectSerializer : IProjectSerializer
	{
		private readonly IDataFactory _dataFactory;

		public ProjectSerializer(IDataFactory dataFactory)
		{
			_dataFactory = dataFactory;
		}

		public IProject Deserialize(string content)
		{
			var document = XDocument.Parse(content, LoadOptions.PreserveWhitespace);
			var pom = new ProjectObjectModel(document);
			var project = _dataFactory.CreateProject();
			LoadProject(pom, project);
			return project;
		}

		public string Serialize(IProject project)
		{
			var pom = new ProjectObjectModel();
			SaveProject(project, pom);
			return pom.ToString();
		}


		// REVIEW: element is not ProjectObjectModel, it is wrapper XElement (dependency, parent)
		internal void LoadProjectReference(ProjectObjectModel pom, XElement startElement, IProjectReference projectReference)
		{
			projectReference.ArtifactId = pom.ReadElementValueOrNull(startElement, "artifactId");
			projectReference.GroupId = pom.ReadElementValueOrNull(startElement, "groupId");
			projectReference.Version = pom.ReadElementValueOrNull(startElement, "version");
		}

		// REVIEW: element is not ProjectObjectModel, it is wrapper XElement (dependency, parent)
		internal void SaveProjectReference(IProjectReference projectReference, ProjectObjectModel pom, XElement startElement)
		{
			pom.SetElementValue(startElement, "groupId", projectReference.GroupId);
			pom.SetElementValue(startElement, "artifactId", projectReference.ArtifactId);
			pom.SetElementValue(startElement, "version", projectReference.Version);
		}

		internal void LoadParentReference(ProjectObjectModel pom, IProject project)
		{
			var parentElement = pom.ReadElementOrNull("parent");
			if (parentElement == null)
			{
				project.Parent = null;
			}
			else
			{
				var parentReference = _dataFactory.CreateParentReference();
				LoadProjectReference(pom, parentElement, parentReference);
				parentReference.RelativePath = pom.ReadElementValueOrNull(parentElement, "relativePath");
				project.Parent = parentReference;
			}
		}

		internal void SaveParentReference(IProject project, ProjectObjectModel pom)
		{
			IParentReference parentReference = project.Parent;
			if (parentReference == null)
			{
				pom.RemoveElement("parent");
			}
			else
			{
				var parentElement = pom.SingleOrCreate(pom.RootElement, "parent");
				SaveProjectReference(parentReference, pom, parentElement);
				pom.SetElementValue(parentElement, "relativePath", parentReference.RelativePath);
			}
		}

		internal IModule LoadModule(XElement element)
		{
			var module = _dataFactory.CreateModule();
			module.Path = element.Value;
			return module;
		}

		public void SaveModule(IModule module, XElement element)
		{
			element.Value = module.Path;
		}

		internal void LoadBuildContainer(ProjectObjectModel pom, XElement startElement, IBuildContainer container)
		{
			////load project properties
			//var propertiesNode = element.ReadElement("properties");
			//if (propertiesNode != null)
			//{
			//	Properties = propertiesNode.Elements
			//		.Select(e => (IProperty)new Property(e)).ToList();
			//}

			//load modules
			container.Modules = pom
				.ReadElements(startElement, "modules", "module")
				.Select(LoadModule)
				.ToList();

			////load dependencies
			//Dependencies = element.ReadElements("dependencies", "dependency")
			//	.Select(e => _dataFactory.CreateDependency(e)).ToList();

			//// load plugins 
			//Plugins = element.ReadElements("build", "plugins", "plugin")
			//	.Select(e => _dataFactory.CreatePlugin(e)).ToList();

			//// load pluginManagement 
			//PluginManagement = element.ReadElements("build", "pluginManagement", "plugins", "plugin")
			//	.Select(e => _dataFactory.CreatePlugin(e)).ToList();
		}

		internal void SaveBuildContainer(IBuildContainer container, ProjectObjectModel pom, XElement startElement)
		{
			//writing modules
			if (!container.Modules.Any())
			{
				pom.RemoveElement(startElement, "modules");
			}
			else
			{
				var modulesNode = pom.SingleOrCreate(startElement, "modules");
				pom.RemoveAllChildElements(modulesNode);
				foreach (IModule module in container.Modules.Where(m => !string.IsNullOrEmpty(m.Path)))
				{
					var moduleNode = pom.AddElement(modulesNode, "module");
					SaveModule(module, moduleNode);
				}
			}

			////writing dependencies
			//var dependenciesNode = element.ReadOrCreateElement("dependencies");
			//if (!Dependencies.Any())
			//{
			//	dependenciesNode.Remove();
			//}
			//else
			//{
			//	dependenciesNode.RemoveAllChildElements();
			//	foreach (Dependency dependency in Dependencies)
			//	{
			//		var dependencyNode = dependenciesNode.CreateElement("dependency");
			//		dependency.SaveToElement(dependencyNode);
			//	}
			//}

			////writing properties
			//var propertiesNode = element.ReadOrCreateElement("properties");
			//if (!Properties.Any())
			//{
			//	propertiesNode.Remove();
			//}
			//else
			//{
			//	propertiesNode.RemoveAllChildElements();
			//	foreach (Property prop in Properties)
			//	{
			//		prop.SaveTo(propertiesNode);
			//	}
			//}

			//var buildNode = element.ReadOrCreateElement("build");
			//if (!Plugins.Any() && !PluginManagement.Any()) // empty build section 
			//{
			//	buildNode.Remove();
			//}
			//else
			//{
			//	var pluginsNode = buildNode.ReadOrCreateElement("plugins");
			//	if (!Plugins.Any())
			//	{
			//		pluginsNode.Remove();
			//	}
			//	else
			//	{
			//		pluginsNode.RemoveAllChildElements();
			//		foreach (Plugin plugin in Plugins)
			//		{
			//			var pluginNode = pluginsNode.CreateElement("plugin");
			//			plugin.SaveToElement(pluginNode);
			//		}
			//	}

			//	var pluginManagementNode = buildNode.ReadOrCreateElement("pluginManagement");
			//	var pluginManagementPluginsNode = pluginManagementNode.ReadOrCreateElement("plugins");

			//	if (!PluginManagement.Any())
			//	{
			//		pluginManagementNode.Remove();
			//	}
			//	else
			//	{
			//		pluginManagementPluginsNode.RemoveAllChildElements();
			//		foreach (Plugin plugin in PluginManagement)
			//		{
			//			var pluginNode = pluginManagementPluginsNode.CreateElement("plugin");
			//			plugin.SaveToElement(pluginNode);
			//		}
			//	}
			//}
		}


		internal void LoadProject(ProjectObjectModel pom, IProject project)
		{
			LoadProjectReference(pom, pom.RootElement, project);
			LoadParentReference(pom, project);

			project.Packaging = pom.ReadElementValueOrNull("packaging");
			project.Name = pom.ReadElementValueOrNull("name");
			project.ModelVersion = pom.ReadElementValueOrNull("modelVersion");

			LoadBuildContainer(pom, pom.RootElement, project);
			//_container.LoadFromElement(element);

			////load profiles
			//Profiles = element.ReadElements("profiles", "profile")
			//	.Select(e => _dataFactory.CreateProfile(e)).ToList();
		}

		internal void SaveProject(IProject project, ProjectObjectModel pom)
		{
			// XElement root = element.RootElement;

			SaveProjectReference(project, pom, pom.RootElement);
			SaveParentReference(project, pom);

			pom.SetElementValue("packaging", project.Packaging);
			pom.SetElementValue("name", project.Name);
			pom.SetElementValue("modelVersion", project.ModelVersion);

			SaveBuildContainer(project, pom, pom.RootElement);

			////writing profiles
			//var profileNode = pom.SingleOrCreate("profiles");
			//if (!Profiles.Any())
			//{
			//	profileNode.Remove();
			//}
			//else
			//{
			//	HashSet<PomXmlElement> usedElements = new HashSet<PomXmlElement>();
			//	foreach (Profile prof in Profiles)
			//	{
			//		var profElement = profileNode.Elements.FirstOrDefault(e => e.ReadElementValue("id") == prof.Id) ??
			//								profileNode.CreateElement("profile");

			//		usedElements.Add(profElement);
			//		prof.SaveToElement(profElement);
			//	}

			//	//delete all profiles elements which are not in the Profiles array
			//	foreach (var profElem in profileNode.Elements.Where(e => !usedElements.Contains(e)))
			//		profElem.Remove();
			//}
		}

	}
}
