using CodingAssessment.Features.Sales.GetTopSellingSales;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.Sales;

[Controller]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISender _mediator;

    public SalesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("top/{topCount}")]
    public async Task<IActionResult> GetTopSellers(int topCount, CancellationToken cancellationToken)
    {
        var query = new GetTopSellingSalesQuery(topCount);
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}