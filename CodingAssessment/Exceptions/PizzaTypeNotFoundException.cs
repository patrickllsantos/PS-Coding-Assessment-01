namespace CodingAssessment.Exceptions;

public class PizzaTypeNotFoundException : Exception
{
    public PizzaTypeNotFoundException()
    {
    }
    
    public PizzaTypeNotFoundException(string message) : base(message)
    {
    }
}