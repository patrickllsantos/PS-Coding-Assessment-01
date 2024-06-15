using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.Orders.GetOrders;

/// <summary>
/// Represents the response containing orders and pagination metadata.
/// </summary>
/// <param name="Orders">The list of orders.</param>
/// <param name="Pagination">The pagination metadata.</param>
public record GetOrdersResponse(
    List<OrderResponse> Orders, 
    Pagination Pagination
);