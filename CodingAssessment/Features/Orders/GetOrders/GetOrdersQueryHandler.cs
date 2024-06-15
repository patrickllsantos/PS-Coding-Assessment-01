using CodingAssessment.Database;
using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.Features.Orders.GetOrders;

/// <summary>
/// Handler for the <see cref="GetOrdersQuery"/>.
/// </summary>
public static class GetOrdersQueryHandler
{
    internal sealed class Handler : IRequestHandler<GetOrdersQuery, GetOrdersResponse>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<GetOrdersResponse> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var req = request.Request;
            var skip = req.PaginationParams.PageSize * (req.PaginationParams.PageNumber - 1);
            var take = req.PaginationParams.PageSize;

            var orders = await _context.Orders
                .Select(x => new OrderResponse
                {
                    Id = x.Id,
                    Date = x.Date,
                    Time = x.Time
                })
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);
            
            var totalCount = await _context.Orders.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling(totalCount / (double)req.PaginationParams.PageSize);
            var paginationMetadata = new Pagination(req.PaginationParams.PageNumber, totalPages,
                req.PaginationParams.PageSize, totalCount);

            var response = new GetOrdersResponse(orders, paginationMetadata);

            return response;
        }
    }
}