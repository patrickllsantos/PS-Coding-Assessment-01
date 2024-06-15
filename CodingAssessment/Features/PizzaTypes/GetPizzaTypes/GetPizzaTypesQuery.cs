using MediatR;

namespace CodingAssessment.Features.PizzaTypes.GetPizzaTypes;

/// <summary>
/// Represents a query to get pizza types.
/// </summary>
/// <param name="Request">The request containing pagination parameters.</param>
public record GetPizzaTypesQuery(GetPizzaTypesRequest Request) : IRequest<GetPizzaTypesResponse>;
