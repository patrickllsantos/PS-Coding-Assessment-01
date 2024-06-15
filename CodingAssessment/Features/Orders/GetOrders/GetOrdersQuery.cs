using MediatR;

namespace CodingAssessment.Features.Orders.GetOrders;

public record GetOrdersQuery(GetOrdersRequest Request) : IRequest<GetOrdersResponse>;