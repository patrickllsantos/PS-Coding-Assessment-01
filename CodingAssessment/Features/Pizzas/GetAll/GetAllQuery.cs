using MediatR;

namespace CodingAssessment.Features.Pizzas.GetAll;

public record GetAllQuery(GetAllRequest Request) : IRequest<GetAllResponse>;