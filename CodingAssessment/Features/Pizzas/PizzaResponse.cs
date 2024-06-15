namespace CodingAssessment.Features.Pizzas;

public class PizzaResponse
{
    public string Id { get; set; } = string.Empty;

    public string PizzaType { get; set; } = string.Empty;

    public string Size { get; set; } = string.Empty;

    public decimal Price { get; set; }
}