using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.PizzaTypes;

[Controller]
[Route("api/[controller]")]
public class PizzaTypesController : ControllerBase
{
    private readonly ISender _mediator;

    public PizzaTypesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import(ImportPizzaTypes.Request request, CancellationToken cancellationToken)
    {
        var command = new ImportPizzaTypes.Command(request);
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
}