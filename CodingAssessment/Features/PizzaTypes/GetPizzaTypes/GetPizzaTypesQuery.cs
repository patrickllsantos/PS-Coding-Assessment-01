using CodingAssessment.Models.Pagination;
using MediatR;

namespace CodingAssessment.Features.PizzaTypes.GetAll;

public record GetPizzaTypesQuery(GetPizzaTypesRequest Request) : IRequest<GetPizzaTypesResponse>;