using MediatR;

namespace CodingAssessment.Features.Orders.GetAll;

public record GetOrdersQuery(GetOrdersRequest Request) : IRequest<GetOrdersResponse>;