namespace Pustota.Maven.Editor.Validations
{
	internal interface IValidationOutput
	{
		void AddError(ValidationError error);
	}
}