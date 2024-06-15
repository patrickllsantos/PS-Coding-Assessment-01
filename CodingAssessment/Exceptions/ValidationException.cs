namespace CodingAssessment.Exceptions;

/// <summary>
/// Represents errors that occur during validation.
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    /// Gets the validation errors.
    /// </summary>
    public IEnumerable<string> Errors { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ValidationException(string message) : base(message)
    {
        Errors = new List<string> { message };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class with a collection of error messages.
    /// </summary>
    /// <param name="errorMessages">The collection of error messages.</param>
    public ValidationException(IEnumerable<string> errorMessages) : base("One or more validation errors occurred.")
    {
        Errors = errorMessages;
    }
}
