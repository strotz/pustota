using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pustota.Maven.Base;
using Pustota.Maven.Base.Serialization;

namespace Pustota.Maven.Cmd
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				if (args.Length != 1)
				{
					Console.WriteLine("Need top folder location");
					return;
				}

				string topFolder = args[0];

				var work = new Work(topFolder);
				work.LoadProjects();
				Console.WriteLine(work.Projects.Count() + " projects loaded");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}
	}
}
