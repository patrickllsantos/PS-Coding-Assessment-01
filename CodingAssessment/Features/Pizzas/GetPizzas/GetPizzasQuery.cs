using MediatR;

namespace CodingAssessment.Features.Pizzas.GetAll;

public record GetPizzasQuery(GetPizzasRequest Request) : IRequest<GetPizzasResponse>;