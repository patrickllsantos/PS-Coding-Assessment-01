using MediatR;

namespace CodingAssessment.Features.OrderDetails.GetAll;

public record GetAllQuery(GetAllRequest Request) : IRequest<GetAllResponse>;