using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.Pizzas.GetPizzas;

/// <summary>
/// Represents the request to get pizzas.
/// </summary>
/// <param name="PaginationParams">The pagination parameters.</param>
public record GetPizzasRequest([FromQuery] PaginationParams PaginationParams) : IRequest<GetPizzasResponse>;