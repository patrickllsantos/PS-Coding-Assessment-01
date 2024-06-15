using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.OrderDetails.GetOrderDetails;

/// <summary>
/// Represents the request to get order details.
/// </summary>
/// <param name="PaginationParams">The pagination parameters.</param>
public record GetOrderDetailsRequest([FromQuery] PaginationParams PaginationParams) : IRequest<GetOrderDetailsResponse>;