using MediatR;

namespace CodingAssessment.Features.Orders.GetOrders;

/// <summary>
/// Represents a query to get orders.
/// </summary>
/// <param name="Request">The request containing pagination parameters.</param>
public record GetOrdersQuery(GetOrdersRequest Request) : IRequest<GetOrdersResponse>;