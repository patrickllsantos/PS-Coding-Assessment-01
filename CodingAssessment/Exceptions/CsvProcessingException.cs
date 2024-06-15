namespace CodingAssessment.Exceptions;

/// <summary>
/// Represents errors that occur during CSV processing.
/// </summary>
public class CsvProcessingException : Exception
{
    public CsvProcessingException()
    {
    }

    public CsvProcessingException(string message) : base(message)
    {
    }

    
    public CsvProcessingException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
