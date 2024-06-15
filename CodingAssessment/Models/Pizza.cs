using CodingAssessment.Models.Enums;

namespace CodingAssessment.Models;

/// <summary>
/// Represents the pizza
/// </summary>
public class Pizza
{
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the pizza.
    /// </summary>
    /// <remarks>
    /// Navigation property for the type of the pizza.
    /// </remarks>
    public PizzaType PizzaType { get; set; }
    
    /// <summary>
    /// Gets or sets the pizza type id
    /// </summary>
    public required string PizzaTypeId { get; set; }

    /// <summary>
    /// Gets or sets the size of the pizza.
    /// </summary>
    public required Size Size { get; set; }

    /// <summary>
    /// Gets or sets the price of the pizza.
    /// </summary>
    public required decimal Price { get; set; }
    
    /// <summary>
    /// Gets or sets the collection of order details for this pizza.
    /// </summary>
    public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}