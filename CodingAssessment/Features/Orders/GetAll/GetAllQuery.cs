using MediatR;

namespace CodingAssessment.Features.Orders.GetAll;

public record GetAllQuery(GetAllRequest Request) : IRequest<GetAllResponse>;