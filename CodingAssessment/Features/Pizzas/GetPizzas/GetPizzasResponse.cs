using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.Pizzas.GetPizzas;

public record GetPizzasResponse(
    List<PizzaResponse> Pizzas, 
    Pagination Pagination
);