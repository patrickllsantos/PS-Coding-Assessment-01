using MediatR;

namespace CodingAssessment.Features.Pizzas.GetPizzas;

/// <summary>
/// Represents a query to get pizzas.
/// </summary>
/// <param name="Request">The request containing pagination parameters.</param>
public record GetPizzasQuery(GetPizzasRequest Request) : IRequest<GetPizzasResponse>;