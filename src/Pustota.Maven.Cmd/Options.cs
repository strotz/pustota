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

		[VerbOption("enableSnapshot", HelpText = "Switch to snapshot project and all dependent projects in repo")]
		public EnableSnapshotCommand EnableSnapshotCommand { get; set; }

		[VerbOption("normalize", HelpText = "Normalize all projects in repo")]
		public NormalizeCommand NormalizeCommand { get; set; }

		[VerbOption("applyClassifier", HelpText = "Apply specific value to classifier for all dependencies")]
		public ApplyClassifierCommand ApplyClassifierCommand { get; set; }

		[VerbOption("dumpClassifiers", HelpText = "Dump titles of classifiers for all dependencies")]
		public DumpClassifiersCommand DumpClassifiersCommand { get; set; }

		[VerbOption("validate", HelpText = "Validate project tree")]
		public ValidateAndFixCommand ValidateAndFixCommand { get; set; }

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

				case "dumpClassifiers":
					DumpClassifiersCommand.Execute();
					break;

				case "validate":
					ValidateAndFixCommand.Execute();
					break;

				case "enableSnapshot":
					EnableSnapshotCommand.Execute();
					break;
			}
		}
	}
}