using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.PizzaTypes.GetPizzaTypes;

public record GetPizzaTypesRequest([FromQuery] PaginationParams PaginationParams) : IRequest<GetPizzaTypesResponse>;