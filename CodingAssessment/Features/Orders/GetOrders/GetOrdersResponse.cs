using CodingAssessment.Models;
using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.Orders.GetAll;

public record GetOrdersResponse(
    List<OrderResponse> Orders, 
    Pagination Pagination
);