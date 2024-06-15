using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.Pizzas.GetAll;

public record GetAllRequest([FromQuery] PaginationParams PaginationParams) : IRequest<GetAllResponse>;