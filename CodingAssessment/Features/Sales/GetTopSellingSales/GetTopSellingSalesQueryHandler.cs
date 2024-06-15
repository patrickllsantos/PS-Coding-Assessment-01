using CodingAssessment.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.Features.Sales.GetTopSellingSales;

/// <summary>
/// Handler for the <see cref="GetTopSellingSalesQuery"/>.
/// </summary>
public static class GetTopSellingSalesQueryHandler
{
    internal sealed class Handler : IRequestHandler<GetTopSellingSalesQuery, GetTopSellingSalesResponse>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<GetTopSellingSalesResponse> Handle(GetTopSellingSalesQuery request, CancellationToken cancellationToken)
        {
            var topSellers = await _context.OrderDetails
                .Include(x => x.Pizza)
                .ThenInclude(x => x.PizzaType)
                .GroupBy(x => x.Pizza.PizzaType.Name)
                .Select(x => new TopSeller
                {
                    Name = x.Key,
                    TotalQuantitySold = x.Sum(od => od.Quantity)
                })
                .OrderByDescending(x => x.TotalQuantitySold)
                .Take(request.TopCount > 100 ? 100 : request.TopCount)
                .ToListAsync(cancellationToken);

            var response = new GetTopSellingSalesResponse(topSellers);
            
            return response;
        }
    }
}