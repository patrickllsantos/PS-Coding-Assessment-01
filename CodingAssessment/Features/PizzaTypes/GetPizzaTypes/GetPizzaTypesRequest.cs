using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.PizzaTypes.GetPizzaTypes;

/// <summary>
/// Represents the request to get pizza types.
/// </summary>
/// <param name="PaginationParams">The pagination parameters.</param>
public record GetPizzaTypesRequest([FromQuery] PaginationParams PaginationParams) : IRequest<GetPizzaTypesResponse>;