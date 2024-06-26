﻿using CodingAssessment.Features.Pizzas.GetPizzas;
using CodingAssessment.Features.Pizzas.ImportPizzas;
using CodingAssessment.Models.Pagination;
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

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams,
        CancellationToken cancellationToken)
    {
        var query = new GetPizzasQuery(new GetPizzasRequest(paginationParams));
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import(ImportPizzasRequest pizzasRequest, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ImportPizzasCommand(pizzasRequest), cancellationToken);
        return NoContent();
    }
}