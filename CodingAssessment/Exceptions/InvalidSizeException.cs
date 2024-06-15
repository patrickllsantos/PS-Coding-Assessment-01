namespace CodingAssessment.Exceptions;

public class InvalidSizeException : Exception
{
    public InvalidSizeException()
    {
    }

    public InvalidSizeException(string message) : base(message)
    {
    }
}