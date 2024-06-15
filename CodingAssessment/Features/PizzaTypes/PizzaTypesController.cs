using CodingAssessment.Features.PizzaTypes.GetPizzaTypes;
using CodingAssessment.Features.PizzaTypes.ImportPizzaTypes;
using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.PizzaTypes;

/// <summary>
/// API controller for managing pizza types.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PizzaTypesController : ControllerBase
{
    private readonly ISender _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="PizzaTypesController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator for sending commands and queries.</param>
    public PizzaTypesController(ISender mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets all pizza types with pagination.
    /// </summary>
    /// <param name="paginationParams">The pagination parameters.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of pizza types with pagination metadata.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams, CancellationToken cancellationToken)
    {
        var query = new GetPizzaTypesQuery(new GetPizzaTypesRequest(paginationParams));
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Imports pizza types from a request.
    /// </summary>
    /// <param name="pizzaTypesRequest">The pizza types import request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>No content result.</returns>
    [HttpPost("import")]
    public async Task<IActionResult> Import(ImportPizzaTypesRequest pizzaTypesRequest, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ImportPizzaTypesCommand(pizzaTypesRequest), cancellationToken);
        return NoContent();
    }
}
