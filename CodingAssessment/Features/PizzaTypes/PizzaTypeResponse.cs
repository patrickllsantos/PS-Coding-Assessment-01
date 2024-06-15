namespace CodingAssessment.Features.PizzaTypes;

/// <summary>
/// Represents the response model for a pizza type.
/// </summary>
public class PizzaTypeResponse
{
    /// <summary>
    /// Gets or sets the unique identifier for the pizza type.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the pizza type.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category of the pizza type.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ingredients of the pizza type.
    /// </summary>
    public string Ingredients { get; set; } = string.Empty;
}
