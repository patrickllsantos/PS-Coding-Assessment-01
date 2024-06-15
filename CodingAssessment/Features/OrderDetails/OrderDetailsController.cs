using CodingAssessment.Features.OrderDetails.GetAll;
using CodingAssessment.Features.OrderDetails.Import;
using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.OrderDetails;

[Controller]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly ISender _mediator;

    public OrderDetailsController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams,
        CancellationToken cancellationToken)
    {
        var query = new GetOrderDetailsQuery(new GetOrderDetailsRequest(paginationParams));
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost("import")]
    public async Task<IActionResult> Import(ImportRequest request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ImportCommand(request), cancellationToken);
        return NoContent();
    }

}