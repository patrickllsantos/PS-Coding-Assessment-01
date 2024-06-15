namespace CodingAssessment.Features.OrderDetails;

/// <summary>
/// Represents the response model for order details.
/// </summary>
public class OrderDetailsResponse
{
    /// <summary>
    /// Gets or sets the unique identifier for the order detail.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier for the associated order.
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Gets or sets the identifier for the associated pizza.
    /// </summary>
    public string PizzaId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of pizzas in the order detail.
    /// </summary>
    public int Quantity { get; set; }
}
