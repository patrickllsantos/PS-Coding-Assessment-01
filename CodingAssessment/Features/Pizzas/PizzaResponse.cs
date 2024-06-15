namespace CodingAssessment.Features.Pizzas;

/// <summary>
/// Represents the response model for a pizza.
/// </summary>
public class PizzaResponse
{
    /// <summary>
    /// Gets or sets the unique identifier for the pizza.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the pizza type.
    /// </summary>
    public string PizzaType { get; set; }

    /// <summary>
    /// Gets or sets the size of the pizza.
    /// </summary>
    public string Size { get; set; }

    /// <summary>
    /// Gets or sets the price of the pizza.
    /// </summary>
    public decimal Price { get; set; }
}
