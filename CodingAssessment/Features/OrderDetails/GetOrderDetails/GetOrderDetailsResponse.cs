using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.OrderDetails.GetOrderDetails;

/// <summary>
/// Represents the response containing order details and pagination metadata.
/// </summary>
/// <param name="Orders">The list of order details.</param>
/// <param name="Pagination">The pagination metadata.</param>
public record GetOrderDetailsResponse(
    List<OrderDetailsResponse> Orders, 
    Pagination Pagination
);