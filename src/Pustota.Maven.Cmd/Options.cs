using CommandLine;
using CommandLine.Text;
using Pustota.Maven.Cmd.Commands;

namespace Pustota.Maven.Cmd
{
	class Options
	{
		public Options()
		{
			// Since we create this instance the parser will not overwrite it
			ReleaseAllCommand = new ReleaseAllCommand();
			NormalizeCommand = new NormalizeCommand();
		}

		[VerbOption("releaseAll", HelpText = "Release all snapshot projects in repo")]
		public ReleaseAllCommand ReleaseAllCommand { get; set; }

		[VerbOption("normalize", HelpText = "Normalize all projects in repo")]
		public NormalizeCommand NormalizeCommand { get; set; }

		[VerbOption("applyClassifier", HelpText = "Apply specific value to classifier for all dependencies")]
		public ApplyClassifierCommand ApplyClassifierCommand { get; set; }

		[HelpVerbOption]
		public string GetUsage(string verb)
		{
			return HelpText.AutoBuild(this, verb);
		}

		internal void ExecuteVerb(string verb)
		{
			switch (verb)
			{
				case "releaseAll":
					ReleaseAllCommand.Execute();
					break;

				case "normalize":
					NormalizeCommand.Execute();
					break;

				case "applyClassifier":
					ApplyClassifierCommand.Execute();
					break;
			}
		}
	}
}