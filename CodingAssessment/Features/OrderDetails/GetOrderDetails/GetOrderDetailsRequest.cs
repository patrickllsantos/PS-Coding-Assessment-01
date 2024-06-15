using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.OrderDetails.GetAll;

public record GetOrderDetailsRequest([FromQuery] PaginationParams PaginationParams) : IRequest<GetOrderDetailsResponse>;