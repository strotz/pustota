using System;
using System.Xml.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	internal class DataFactory : IDataFactory
	{
		// REVIEW
//		ProjectSerializer serializer = new ProjectSerializer();

		// TODO: factory
		public IParentReference CreateParentReference(PomXmlElement parentNode)
		{
			//var parent = new ParentReference();
			//parent.LoadFromElement(parentNode);
			//return parent;
			throw new NotImplementedException();
		}

		public IPlugin CreatePlugin(PomXmlElement element)
		{
			//var plugin = new Plugin();
			//plugin.LoadFromElement(element);
			//return plugin;
			throw new NotImplementedException();
		}

		public IProfile CreateProfile(PomXmlElement element)
		{
			//var profile = new Profile();
			//profile.LoadFromElement(element);
			//return profile;
			throw new NotImplementedException();
		}

		public IProject CreateProject()
		{
			return new Project();
		}

		public IDependency CreateDependency(PomXmlElement element)
		{
			//var dependency = new Dependency();
			//dependency.LoadFromElement(element);
			//return dependency;
			throw new NotImplementedException();
		}
	}
}