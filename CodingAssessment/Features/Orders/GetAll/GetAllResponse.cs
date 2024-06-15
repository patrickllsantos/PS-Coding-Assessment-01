using CodingAssessment.Models;
using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.Orders.GetAll;

public record GetAllResponse(
    List<OrderDto> Orders, 
    Pagination Pagination
);