using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.Orders.GetAll;

public record GetAllRequest([FromQuery] PaginationParams PaginationParams) : IRequest<GetAllResponse>;