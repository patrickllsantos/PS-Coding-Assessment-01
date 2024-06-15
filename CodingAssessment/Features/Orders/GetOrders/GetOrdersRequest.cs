using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.Orders.GetOrders;

public record GetOrdersRequest([FromQuery] PaginationParams PaginationParams) : IRequest<GetOrdersResponse>;