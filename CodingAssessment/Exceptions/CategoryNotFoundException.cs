namespace CodingAssessment.Exceptions;

/// <summary>
/// Represents errors that occur when a specified pizza category is not found.
/// </summary>
public class CategoryNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryNotFoundException"/> class.
    /// </summary>
    public CategoryNotFoundException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryNotFoundException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public CategoryNotFoundException(string message) : base(message)
    {
    }
}
