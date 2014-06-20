using System;
using System.Xml.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	internal class DataFactory : IDataFactory
	{
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

		public IParentReference CreateParentReference()
		{
			return new ParentReference();
		}

		public IProperty CreateProperty()
		{
			return new Property();
		}

		public IModule CreateModule()
		{
			return new Module();
		}

		public IDependency CreateDependency()
		{
			return new Dependency();
		}
	}
}