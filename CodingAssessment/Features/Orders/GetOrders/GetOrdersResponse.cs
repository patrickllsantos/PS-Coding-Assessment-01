using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.Orders.GetOrders;

public record GetOrdersResponse(
    List<OrderResponse> Orders, 
    Pagination Pagination
);