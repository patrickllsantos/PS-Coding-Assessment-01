using CodingAssessment.Features.OrderDetails.Import;
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
    
    [HttpPost("import")]
    public async Task<IActionResult> Import(ImportRequest request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ImportCommand(request), cancellationToken);
        return NoContent();
    }

}