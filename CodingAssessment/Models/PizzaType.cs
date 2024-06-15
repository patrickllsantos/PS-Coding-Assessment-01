namespace CodingAssessment.Models;

/// <summary>
/// Represents the pizza type
/// </summary>
public class PizzaType
{
    /// <summary>
    /// Gets or sets the unique identifier for the order
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the pizza
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the pizza.
    /// </summary>
    /// <remarks>
    /// Navigation property for the category of the pizza type.
    /// </remarks>
    public PizzaCategory Category { get; }

    /// <summary>
    /// Gets or sets the category id
    /// </summary>
    public required int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the ingredients
    /// </summary>
    public required string Ingredients { get; set; }
}