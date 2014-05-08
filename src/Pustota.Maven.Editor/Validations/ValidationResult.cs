namespace Pustota.Maven.Editor.Validations
{
	public enum ValidationResult // REVIEW: im not sure that it will help
	{
		Good, // everything is good
		ProjectWarning, // validation failed, but can continue with same project
		ProjectFatal // no reason to continue with this project
	}
}