namespace CodingAssessment.Features.Orders;

/// <summary>
/// Represents the response model for an order.
/// </summary>
public class OrderResponse
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
}
