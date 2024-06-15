using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.OrderDetails.GetOrderDetails;

public record GetOrderDetailsResponse(
    List<OrderDetailsResponse> Orders, 
    Pagination Pagination
);