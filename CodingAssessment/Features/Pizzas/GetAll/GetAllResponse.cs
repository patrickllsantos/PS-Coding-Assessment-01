using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.Pizzas.GetAll;

public record GetAllResponse(
    List<PizzaDto> Pizzas, 
    Pagination Pagination
);