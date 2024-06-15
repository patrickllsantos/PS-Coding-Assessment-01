using MediatR;

namespace CodingAssessment.Features.PizzaTypes.GetPizzaTypes;

public record GetPizzaTypesQuery(GetPizzaTypesRequest Request) : IRequest<GetPizzaTypesResponse>;