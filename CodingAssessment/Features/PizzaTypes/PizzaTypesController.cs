using CodingAssessment.Features.PizzaTypes.Import;
using CodingAssessment.Models.Pagination;
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
    public async Task<IActionResult> Import(ImportRequest request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ImportCommand(request), cancellationToken);
        return Ok();
    }
}