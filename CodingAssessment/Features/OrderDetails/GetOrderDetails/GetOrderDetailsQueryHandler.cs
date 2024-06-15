using CodingAssessment.Database;
using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.Features.OrderDetails.GetOrderDetails;

/// <summary>
/// Handler for the <see cref="GetOrderDetailsQuery"/>.
/// </summary>
public static class GetOrderDetailsQueryHandler
{
    internal sealed class Handler : IRequestHandler<GetOrderDetailsQuery, GetOrderDetailsResponse>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<GetOrderDetailsResponse> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var req = request.Request;
            var skip = req.PaginationParams.PageSize * (req.PaginationParams.PageNumber - 1);
            var take = req.PaginationParams.PageSize;

            var orderDetails = await _context.OrderDetails
                .Select(x => new OrderDetailsResponse
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    OrderId = x.OrderId,
                    PizzaId = x.PizzaId
                })                
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);
            
            var totalCount = await _context.OrderDetails.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling(totalCount / (double)req.PaginationParams.PageSize);
            var paginationMetadata = new Pagination(req.PaginationParams.PageNumber, totalPages,
                req.PaginationParams.PageSize, totalCount);

            var response = new GetOrderDetailsResponse(orderDetails, paginationMetadata);

            return response;
        }
    }
}
