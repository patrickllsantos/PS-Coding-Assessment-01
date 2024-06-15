namespace CodingAssessment.Features.OrderDetails;

public class OrderDetailsResponse
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string PizzaId { get; set; } = string.Empty;

    public int Quantity { get; set; }
}