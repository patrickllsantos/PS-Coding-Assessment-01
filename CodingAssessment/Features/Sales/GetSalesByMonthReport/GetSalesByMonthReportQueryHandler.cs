using CodingAssessment.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.Features.Sales.GetSalesByMonthReport;

/// <summary>
/// Handler for the <see cref="GetSalesByMonthReportQuery"/>.
/// </summary>
public static class GetSalesByMonthReportQueryHandler
{
    internal sealed class Handler : IRequestHandler<GetSalesByMonthReportQuery, GetSalesByMonthReportResponse>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<GetSalesByMonthReportResponse> Handle(GetSalesByMonthReportQuery request, CancellationToken cancellationToken)
        {
            var sales = await _context.Orders
                .Where(x => x.Date.Year == request.Year)
                .GroupBy(x => new { x.Date.Month, x.Date.Year })
                .Select(x => new SalesByMonthReport
                {
                    Month = x.Key.Month,
                    Year = x.Key.Year,
                    TotalSales = x.SelectMany(o => o.OrderDetails).Sum(od => od.Quantity * od.Pizza.Price)
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync(cancellationToken);

            var response = new GetSalesByMonthReportResponse(sales);

            return response;
        }
    }
}