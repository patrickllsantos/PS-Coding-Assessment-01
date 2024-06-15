namespace CodingAssessment.Features.Pizzas;

public class PizzaDto
{
    public string Id { get; set; } = default!;

    public string PizzaType { get; set; } = default!;

    public string Size { get; set; } = default!;

    public decimal Price { get; set; }
}