using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.PizzaTypes.GetAll;

public record GetAllResponse(
    List<PizzaTypeDto> PizzaTypes, 
    Pagination Pagination
);