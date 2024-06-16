using CodingAssessment.Features.Sales.GetSalesByMonthReport;
using CodingAssessment.Features.Sales.GetTopSellingSales;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.Sales;

/// <summary>
/// API controller for managing sales data.
/// </summary>
[Controller]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISender _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="SalesController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator for sending commands and queries.</param>
    public SalesController(ISender mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets the top-selling pizzas.
    /// </summary>
    /// <param name="topCount">The number of top sellers to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of top-selling pizzas.</returns>
    [HttpGet("top-sellers/{topCount}")]
    public async Task<IActionResult> GetTopSellers(int topCount, CancellationToken cancellationToken)
    {
        var query = new GetTopSellingSalesQuery(topCount);
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Gets the sales data by month for a specified year.
    /// </summary>
    /// <param name="year">The year for which to retrieve sales data.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The sales data by month for the specified year.</returns>
    [HttpGet("by-month/{year}")]
    public async Task<IActionResult> GetSalesByMonth(int year, CancellationToken cancellationToken)
    {
        var query = new GetSalesByMonthReportQuery(year);
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}
