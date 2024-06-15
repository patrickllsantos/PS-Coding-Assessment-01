namespace CodingAssessment.Exceptions;

/// <summary>
/// Represents errors that occur during validation.
/// </summary>
public class ValidationException : Exception
{
    public IEnumerable<string> Errors { get; }
    
    public ValidationException(string message) : base(message)
    {
        Errors = new List<string> { message };
    }
    
    public ValidationException(IEnumerable<string> errorMessages) : base("One or more validation errors occurred.")
    {
        Errors = errorMessages;
    }
}
