using CodingAssessment.Features.Orders.Import;
using CodingAssessment.Features.Shared.Import;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.Orders;

[Controller]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ISender _mediator;

    public OrdersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import(ImportRequest request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ImportCommand(request), cancellationToken);
        return NoContent();
    }
}