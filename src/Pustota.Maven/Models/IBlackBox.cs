namespace Pustota.Maven.Models
{
	public interface IBlackBox
	{
		bool IsEmpty { get; }
		object Value { get; } // REVIEW: always casted to PomElement - need better solution 
	}
}