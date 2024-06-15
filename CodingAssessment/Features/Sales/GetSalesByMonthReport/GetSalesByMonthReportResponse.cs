namespace CodingAssessment.Features.Sales.GetSalesByMonthReport;

public record GetSalesByMonthReportResponse(List<SalesByMonthReport> Sales);

public class SalesByMonthReport
{
    public int Month { get; set; }

    public int Year { get; set; }

    public decimal TotalSales { get; set; }
}