using MediatR;

namespace CodingAssessment.Features.Sales.GetSalesByMonthReport;

/// <summary>
/// Represents a query to get sales data by month for a specific year.
/// </summary>
/// <param name="Year">The year for which to retrieve sales data.</param>
public record GetSalesByMonthReportQuery(int Year) : IRequest<GetSalesByMonthReportResponse>;