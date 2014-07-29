using System.Collections;
using System.Collections.Generic;

namespace Pustota.Maven.Validation
{
	public enum ProblemSeverity // REVIEW: im not sure that it will help
	{
		Good, // everything is good
		ProjectWarning, // validation failed, but can continue with same project
		ProjectFatal // no reason to continue with this project
	}

	public interface IValidationProblem
	{
		ProblemSeverity Severity { get; }
		string Description { get; }
	}

	public class ValidationProblem : IValidationProblem
	{
		public ProblemSeverity Severity { get; internal protected set; }
		public string Description { get; internal protected set; }
	}


}