using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.PizzaTypes.GetAll;

public record GetPizzaTypesResponse(
    List<PizzaTypeResponse> PizzaTypes, 
    Pagination Pagination
);