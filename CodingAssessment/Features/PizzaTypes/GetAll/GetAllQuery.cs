using CodingAssessment.Models.Pagination;
using MediatR;

namespace CodingAssessment.Features.PizzaTypes.GetAll;

public record GetAllQuery(GetAllRequest Request) : IRequest<GetAllResponse>;