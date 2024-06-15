namespace CodingAssessment.Exceptions;

/// <summary>
/// Represents errors that occur due to duplicate keys in the database.
/// </summary>
public class DuplicateKeyException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DuplicateKeyException"/> class.
    /// </summary>
    public DuplicateKeyException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DuplicateKeyException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public DuplicateKeyException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DuplicateKeyException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public DuplicateKeyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
