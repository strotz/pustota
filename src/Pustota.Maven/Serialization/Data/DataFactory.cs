using System;
using System.Xml.Linq;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	internal class DataFactory : IDataFactory
	{
		public IPlugin CreatePlugin()
		{
			return new Plugin();
		}

		public IProfile CreateProfile()
		{
			return new Profile();
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