using MediatR;

namespace CodingAssessment.Features.Sales.GetSalesByMonthReport;

public record GetSalesByMonthReportQuery(int Year) : IRequest<GetSalesByMonthReportResponse>;