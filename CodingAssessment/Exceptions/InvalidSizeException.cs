namespace CodingAssessment.Exceptions;

/// <summary>
/// Represents invalid size enum errors.
/// </summary>
public class InvalidSizeException : Exception
{
    public InvalidSizeException()
    {
    }

    public InvalidSizeException(string message) : base(message)
    {
    }
}