using System.Diagnostics;
using Pustota.Maven.Editor.PomXml;

namespace Pustota.Maven.Editor.Models
{
	public class DataFactory
	{
		// TODO: factory
		internal IParentReference CreateParentReference(PomXmlElement parentNode)
		{
			var parent = new ParentReference();
			parent.LoadFromElement(parentNode);
			return parent;
		}

		internal IPlugin CreatePlugin(PomXmlElement element)
		{
			var plugin = new Plugin();
			plugin.LoadFromElement(element);
			return plugin;
		}

		internal IProfile CreateProfile(PomXmlElement element)
		{
			var profile = new Profile();
			profile.LoadFromElement(element);
			return profile;
		}

		internal Project CreateProject()
		{
			var project = new Project();
			return project;
		}

		internal IDependency CreateDependency(PomXmlElement element)
		{
			var dependency = new Dependency();
			dependency.LoadFromElement(element);
			return dependency;
		}
	}
}