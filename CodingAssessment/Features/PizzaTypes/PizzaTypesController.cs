using CodingAssessment.Features.PizzaTypes.GetPizzaTypes;
using CodingAssessment.Features.PizzaTypes.ImportPizzaTypes;
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

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams, CancellationToken cancellationToken)
    {
        var query = new GetPizzaTypesQuery(new GetPizzaTypesRequest(paginationParams));
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost("import")]
    public async Task<IActionResult> Import(ImportPizzaTypesRequest pizzaTypesRequest, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ImportPizzaTypesCommand(pizzaTypesRequest), cancellationToken);
        return NoContent();
    }
}