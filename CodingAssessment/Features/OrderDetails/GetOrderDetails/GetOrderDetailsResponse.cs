using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.OrderDetails.GetAll;

public record GetOrderDetailsResponse(
    List<OrderDetailsResponse> Orders, 
    Pagination Pagination
);