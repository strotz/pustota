using System;
using Pustota.Maven.Models;

namespace Pustota.Maven.Validation
{
	public enum ProblemSeverity // REVIEW: im not sure that it will help
	{
		ProjectWarning, // validation failed, but can continue with same project
		ProjectFatal // no reason to continue with this project
	}

	public interface IProjectValidationProblem
	{
		IProjectReference ProjectReference { get; }
		ProblemSeverity Severity { get; }
		string Description { get; }
	}

	internal class ValidationProblem : IProjectValidationProblem
	{
		internal ValidationProblem(string code)
		{
			if (code == null)
				throw new ArgumentNullException("code");

			ProblemCode = code;
		}

		public IProjectReference ProjectReference { get; internal protected set; }
		public ProblemSeverity Severity { get; internal protected set; }
		public string Description { get; internal protected set; }
		internal string ProblemCode { get; private set; }
	}
}