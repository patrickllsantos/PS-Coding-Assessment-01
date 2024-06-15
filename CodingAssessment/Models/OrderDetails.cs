namespace CodingAssessment.Models;

/// <summary>
/// Represents the details of the placed order by a customer
/// </summary>
public class OrderDetails
{
    /// <summary>
    /// Gets or sets the unique identifier for the order details
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the order associated with the order details.
    /// </summary>
    /// <remarks>
    /// Navigation property for the order associated with the order details.
    /// </remarks>
    public Order Order { get; set; }

    /// <summary>
    /// Gets or sets the order id
    /// </summary>
    public required int OrderId { get; set; }

    /// <summary>
    /// Gets or sets the pizza associated with the order details.
    /// </summary>
    /// <remarks>
    /// Navigation property for the pizza associated with the order details.
    /// </remarks>
    public Pizza Pizza { get; set; }

    /// <summary>
    /// Gets or sets the pizza id
    /// </summary>
    public required string PizzaId { get; set; }

    /// <summary>
    /// Gets or sets the quantity
    /// </summary>
    public required int Quantity { get; set; }
}