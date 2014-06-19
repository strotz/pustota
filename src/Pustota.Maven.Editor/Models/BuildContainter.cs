using System.Collections.Generic;
using System.Linq;
using Pustota.Maven.Editor.PomXml;

namespace Pustota.Maven.Editor.Models
{
	class BuildContainter : IBuildContainer
	{

		private readonly DataFactory _dataFactory;

		public BuildContainter()
		{
			_dataFactory = new DataFactory(); // TODO: DI

			Modules = new List<IModule>();
			Properties = new List<IProperty>();
			Dependencies = new List<IDependency>();
			Plugins = new List<IPlugin>();
			PluginManagement = new List<IPlugin>();
		}

		internal protected virtual void LoadFromElement(PomXmlElement element)
		{
			//load project properties
			var propertiesNode = element.ReadElement("properties");
			if (propertiesNode != null)
			{
				Properties = propertiesNode.Elements
					.Select(e => (IProperty)new Property(e)).ToList();
			}

			//load modules
			Modules = element.ReadElements("modules", "module")
				.Select(e => (IModule)new Module(e)).ToList();

			//load dependencies
			Dependencies = element.ReadElements("dependencies", "dependency")
				.Select(e => _dataFactory.CreateDependency(e)).ToList();

			// load plugins 
			Plugins = element.ReadElements("build", "plugins", "plugin")
				.Select(e => _dataFactory.CreatePlugin(e)).ToList();

			// load pluginManagement 
			PluginManagement = element.ReadElements("build", "pluginManagement", "plugins", "plugin")
				.Select(e => _dataFactory.CreatePlugin(e)).ToList();
		}

		internal protected virtual void SaveToElement(PomXmlElement element)
		{
			//writing modules
			var modulesNode = element.ReadOrCreateElement("modules");
			if (!Modules.Any())
			{
				modulesNode.Remove();
			}
			else
			{
				modulesNode.RemoveAllChildElements();
				foreach (Module module in Modules)
				{
					if (!string.IsNullOrEmpty(module.Path))
					{
						var moduleNode = modulesNode.CreateElement("module");
						module.SaveTo(moduleNode);
					}
				}
			}

			//writing dependencies
			var dependenciesNode = element.ReadOrCreateElement("dependencies");
			if (!Dependencies.Any())
			{
				dependenciesNode.Remove();
			}
			else
			{
				dependenciesNode.RemoveAllChildElements();
				foreach (Dependency dependency in Dependencies)
				{
					var dependencyNode = dependenciesNode.CreateElement("dependency");
					dependency.SaveToElement(dependencyNode);
				}
			}

			//writing properties
			var propertiesNode = element.ReadOrCreateElement("properties");
			if (!Properties.Any())
			{
				propertiesNode.Remove();
			}
			else
			{
				propertiesNode.RemoveAllChildElements();
				foreach (Property prop in Properties)
				{
					prop.SaveTo(propertiesNode);
				}
			}

			var buildNode = element.ReadOrCreateElement("build");
			if (!Plugins.Any() && !PluginManagement.Any()) // empty build section 
			{
				buildNode.Remove();
			}
			else
			{
				var pluginsNode = buildNode.ReadOrCreateElement("plugins");
				if (!Plugins.Any())
				{
					pluginsNode.Remove();
				}
				else
				{
					pluginsNode.RemoveAllChildElements();
					foreach (Plugin plugin in Plugins)
					{
						var pluginNode = pluginsNode.CreateElement("plugin");
						plugin.SaveToElement(pluginNode);
					}
				}

				var pluginManagementNode = buildNode.ReadOrCreateElement("pluginManagement");
				var pluginManagementPluginsNode = pluginManagementNode.ReadOrCreateElement("plugins");

				if (!PluginManagement.Any())
				{
					pluginManagementNode.Remove();
				}
				else
				{
					pluginManagementPluginsNode.RemoveAllChildElements();
					foreach (Plugin plugin in PluginManagement)
					{
						var pluginNode = pluginManagementPluginsNode.CreateElement("plugin");
						plugin.SaveToElement(pluginNode);
					}
				}
			}
		}

	}
}