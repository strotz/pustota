using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pustota.Maven.Base.Serialization;

namespace Pustota.Maven.Cmd
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				string topFolder = args[0];

				var entryPoint = new RepositoryEntryPoint(topFolder);
				var serializer = new ProjectSerializer();

				var loader = new ProjectTreeLoader(entryPoint, serializer, new FileSystemAccess());
				var projects = loader.LoadProjects().ToList();

				Console.WriteLine(projects.Count + " projects loaded");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}
	}
}
