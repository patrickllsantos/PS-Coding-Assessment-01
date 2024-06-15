using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.Pizzas.GetPizzas;

public record GetPizzasRequest([FromQuery] PaginationParams PaginationParams) : IRequest<GetPizzasResponse>;