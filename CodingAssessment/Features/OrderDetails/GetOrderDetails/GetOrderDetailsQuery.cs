using MediatR;

namespace CodingAssessment.Features.OrderDetails.GetAll;

public record GetOrderDetailsQuery(GetOrderDetailsRequest Request) : IRequest<GetOrderDetailsResponse>;