using System.Collections.Generic;

namespace Pustota.Maven.Editor.Validations
{
	class ValidationError
	{
		private readonly List<Fix> _fixes;

		public ErrorLevel Level { get; set; }
		public string Message { get; set; }
		public string Details { get; set; }
		public IFixable Source { get; set; }

		public IEnumerable<Fix> Fixes
		{
			get { return _fixes; }
		}

		public ValidationError(IFixable source, string message, ErrorLevel level) :
			this(source, message, string.Empty, level)
		{
		}

		public ValidationError(IFixable source, string message) :
			this(source, message, string.Empty, ErrorLevel.Error)
		{
		}

		public ValidationError(IFixable source, string message, string details, ErrorLevel level)
		{
			Source = source;
			Message = message;
			Details = details;
			Level = level;
			_fixes = new List<Fix>();
		}

		public void AddFix(Fix fix)
		{
			_fixes.Add(fix);
		}
	}
}
