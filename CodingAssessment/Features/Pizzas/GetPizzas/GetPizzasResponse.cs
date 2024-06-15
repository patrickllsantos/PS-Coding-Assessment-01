using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.Pizzas.GetAll;

public record GetPizzasResponse(
    List<PizzaResponse> Pizzas, 
    Pagination Pagination
);