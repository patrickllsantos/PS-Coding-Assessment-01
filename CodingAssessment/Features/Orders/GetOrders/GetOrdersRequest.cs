using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.Orders.GetOrders;

/// <summary>
/// Represents the request to get orders.
/// </summary>
/// <param name="PaginationParams">The pagination parameters.</param>
public record GetOrdersRequest([FromQuery] PaginationParams PaginationParams) : IRequest<GetOrdersResponse>;