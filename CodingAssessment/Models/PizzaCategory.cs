namespace CodingAssessment.Models;

/// <summary>
/// Represents the categories for pizza
/// </summary>
public class PizzaCategory
{
    /// <summary>
    /// Gets or sets the unique identifier for the pizza category.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the pizza category name
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Gets or sets the pizza types belonging to this category.
    /// </summary>
    /// <remarks>
    /// Navigation property for the pizza types belonging to this category.
    /// </remarks>
    public ICollection<PizzaType> PizzaTypes { get; set; } = new List<PizzaType>();
}