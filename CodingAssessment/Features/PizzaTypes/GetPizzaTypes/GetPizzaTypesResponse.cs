using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.PizzaTypes.GetPizzaTypes;

public record GetPizzaTypesResponse(
    List<PizzaTypeResponse> PizzaTypes, 
    Pagination Pagination
);