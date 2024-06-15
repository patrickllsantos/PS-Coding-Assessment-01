namespace CodingAssessment.Exceptions;

/// <summary>
/// Represents pizza type not found error during data import mapping.
/// </summary>
public class PizzaTypeNotFoundException : Exception
{
    public PizzaTypeNotFoundException()
    {
    }
    
    public PizzaTypeNotFoundException(string message) : base(message)
    {
    }
}