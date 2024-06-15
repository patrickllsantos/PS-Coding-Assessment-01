namespace CodingAssessment.Exceptions;

/// <summary>
/// Represents errors that occur during CSV processing.
/// </summary>
public class CsvProcessingException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CsvProcessingException"/> class.
    /// </summary>
    public CsvProcessingException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CsvProcessingException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public CsvProcessingException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CsvProcessingException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public CsvProcessingException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
