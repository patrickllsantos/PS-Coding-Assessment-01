using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.Pizzas.GetPizzas;

/// <summary>
/// Represents the response containing pizzas and pagination metadata.
/// </summary>
/// <param name="Pizzas">The list of pizzas.</param>
/// <param name="Pagination">The pagination metadata.</param>
public record GetPizzasResponse(
    List<PizzaResponse> Pizzas, 
    Pagination Pagination
);