using CodingAssessment.Features.Orders.GetAll;
using CodingAssessment.Features.Orders.Import;
using CodingAssessment.Models.Pagination;
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
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams,
        CancellationToken cancellationToken)
    {
        var query = new GetAllQuery(new GetAllRequest(paginationParams));
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import(ImportOrdersRequest ordersRequest, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ImportOrdersCommand(ordersRequest), cancellationToken);
        return NoContent();
    }
}