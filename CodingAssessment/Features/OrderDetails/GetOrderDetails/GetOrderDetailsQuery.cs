using MediatR;

namespace CodingAssessment.Features.OrderDetails.GetOrderDetails;

public record GetOrderDetailsQuery(GetOrderDetailsRequest Request) : IRequest<GetOrderDetailsResponse>;