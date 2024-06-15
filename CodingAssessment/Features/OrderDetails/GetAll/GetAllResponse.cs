using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.OrderDetails.GetAll;

public record GetAllResponse(
    List<OrderDetailsResponse> Orders, 
    Pagination Pagination
);