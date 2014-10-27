using System.Collections.Generic;
using Pustota.Maven.Models;

namespace Pustota.Maven.Serialization.Data
{
	internal class Project : 
		ProjectReference,
		IProject 
	{
		public string Name { get; set; }
		public string Packaging { get; set; }
		public string ModelVersion { get; set; }

		public IParentReference Parent { get; set; }

		public List<IProfile> Profiles { get; set; }

		private readonly BuildContainter _container;

		public Project()
		{
			_container = new BuildContainter();
			Profiles = new List<IProfile>();
		}

		// expose build container via adapter
		public List<IModule> Modules
		{
			get { return _container.Modules; }
			set { _container.Modules = value; }
		}

		public List<IDependency> Dependencies
		{
			get { return _container.Dependencies; }
			set { _container.Dependencies = value; }
		}

		public List<IDependency> DependencyManagement
		{
			get { return _container.DependencyManagement; }
			set { _container.DependencyManagement = value; }
		}

		public List<IProperty> Properties
		{
			get { return _container.Properties; }
			set { _container.Properties = value; }
		}

		public List<IPlugin> Plugins
		{
			get { return _container.Plugins; }
			set { _container.Plugins = value; }
		}

		public List<IPlugin> PluginManagement
		{
			get { return _container.PluginManagement; }
			set { _container.PluginManagement = value; }
		}

		public IBlackBox TestResources 
		{ 
			get { return _container.TestResources; }
			set { _container.TestResources = value; }
		}

		public bool Changed { get; set; }
	}
}
