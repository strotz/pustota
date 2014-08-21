﻿using Pustota.Maven.Models;

namespace Pustota.Maven.Validation.Fixes
{
	// REVIEW: 
	internal class ApplyVersionFix : Fix
	{
		private readonly IProjectReference _reference;
		private readonly string _version;

		public ApplyVersionFix(IProjectReference reference, string version)
		{
			_reference = reference;
			_version = version;

			Title = string.Format("version will be changed to {0}", version);
		}

		public override void Do()
		{
			_reference.Version = _version;
			// _project.Changed = true; // REVIEW: project should be notified
		}
	}
}