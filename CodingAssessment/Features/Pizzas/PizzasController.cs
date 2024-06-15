using CodingAssessment.Features.Pizzas.Import;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.Pizzas;

[Controller]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    private readonly ISender _mediator;

    public PizzasController(ISender mediator)
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