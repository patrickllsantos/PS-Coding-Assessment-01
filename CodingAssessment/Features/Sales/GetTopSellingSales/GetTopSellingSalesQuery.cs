using MediatR;

namespace CodingAssessment.Features.Sales.GetTopSellingSales;

/// <summary>
/// Represents a query to get the top-selling pizzas.
/// </summary>
public record GetTopSellingSalesQuery(int TopCount) : IRequest<GetTopSellingSalesResponse>;