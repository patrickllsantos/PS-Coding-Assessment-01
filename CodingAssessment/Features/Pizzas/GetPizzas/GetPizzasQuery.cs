using MediatR;

namespace CodingAssessment.Features.Pizzas.GetPizzas;

public record GetPizzasQuery(GetPizzasRequest Request) : IRequest<GetPizzasResponse>;