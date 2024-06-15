namespace CodingAssessment.Features.Sales.GetSalesByMonthReport;

/// <summary>
/// Represents the response containing sales data by month.
/// </summary>
/// <param name="Sales">The list of sales data by month.</param>
public record GetSalesByMonthReportResponse(List<SalesByMonthReport> Sales);

/// <summary>
/// Represents the sales data for a specific month.
/// </summary>
public class SalesByMonthReport
{
    /// <summary>
    /// Gets or sets the month.
    /// </summary>
    public int Month { get; set; }

    /// <summary>
    /// Gets or sets the year.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the total sales for the month.
    /// </summary>
    public decimal TotalSales { get; set; }
}
