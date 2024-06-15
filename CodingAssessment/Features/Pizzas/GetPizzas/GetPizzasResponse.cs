using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.Pizzas.GetAll;

public record GetPizzasResponse(
    List<PizzaDto> Pizzas, 
    Pagination Pagination
);