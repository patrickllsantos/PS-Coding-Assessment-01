using MediatR;

namespace CodingAssessment.Features.Sales.GetTopSellingSales;

public record GetTopSellingSalesQuery(int topCount) : IRequest<GetTopSellingSalesResponse>;