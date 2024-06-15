using MediatR;

namespace CodingAssessment.Features.OrderDetails.GetOrderDetails;

/// <summary>
/// Represents a query to get order details.
/// </summary>
/// <param name="Request">The request containing pagination parameters.</param>
public record GetOrderDetailsQuery(GetOrderDetailsRequest Request) : IRequest<GetOrderDetailsResponse>;