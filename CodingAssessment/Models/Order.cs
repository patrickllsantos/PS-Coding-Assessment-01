namespace CodingAssessment.Models;

/// <summary>
/// Represents an order placed by a customer.
/// </summary>
public class Order
{
    /// <summary>
    /// Gets or sets the unique identifier for the order.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the date the order was placed.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the time the order was placed.
    /// </summary>
    public TimeSpan Time { get; set; }

    /// <summary>
    /// Gets or sets the details of the order.
    /// </summary>
    /// <remarks>
    /// Navigation property for the details of the order.
    /// </remarks>
    public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}   