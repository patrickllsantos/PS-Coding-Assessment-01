using MediatR;

namespace CodingAssessment.Features.Sales.GetTopSellingSales;

public record GetTopSellingSalesQuery(int TopCount) : IRequest<GetTopSellingSalesResponse>;